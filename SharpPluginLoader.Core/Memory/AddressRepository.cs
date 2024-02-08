﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SharpPluginLoader.Core.Memory
{
    internal static class AddressRepository
    {
        private const string AddressCachePath = "nativePC/plugins/CSharp/Loader/AddressCache.json";
        private const string PluginCachePath = "nativePC/plugins/CSharp/Loader/PluginCache.json";
        public static unsafe void Initialize()
        {
            // Load address records JSON from the chunk.
            var defaultChunk = InternalCalls.GetDefaultChunk();
            var addressRecordsPtr = InternalCalls.ChunkGetFile(defaultChunk, "/Resources/AddressRecords.json");
            var addressRecordsSize = InternalCalls.FileGetSize(addressRecordsPtr);
            var addressRecordsContents = InternalCalls.FileGetContents(addressRecordsPtr);
            var addressRecordsString = Encoding.UTF8.GetString((byte*)addressRecordsContents, (int)addressRecordsSize);
            var addressRecords = JsonSerializer.Deserialize<AddressRecordJson[]>(addressRecordsString, SerializerOptions)
              ?? throw new Exception("Failed to deserialize address records");

            var gameVersion = InternalCalls.GetGameRevision();
            if (string.IsNullOrEmpty(gameVersion))
                throw new Exception("Failed to get game revision");

            // Load Plugin Cache
            LoadPluginRecords();

            Log.Debug($"[Core] Attempting to initialize address repository for game revision: {gameVersion}");
            var addressRecordFileHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(addressRecordsString)));

            if (File.Exists(AddressCachePath))
            {
                // Verify the game client version and AddressRecords.json hash are the same.
                var addressCacheString = File.ReadAllText(AddressCachePath, Encoding.UTF8);
                var cacheRecords = JsonSerializer.Deserialize<AddressRecordCacheJson>(addressCacheString, SerializerOptions)
                              ?? throw new Exception("Failed to deserialize address records cache");

                if (cacheRecords.Version == gameVersion && cacheRecords.AddressRecordFileHash == addressRecordFileHash)
                {
                    Log.Debug("[Core] Restoring from address record cache.");

                    foreach (var record in cacheRecords.Addresses)
                    {
                        Records[record.Key] = (nint)record.Value;
                    }

                    // Restored from cache, return early.
                    return;
                }
            }

            // Either the cache file doesn't exist, or the version/file hash didn't match.
            // So we AOB scan in cache.
            Log.Debug("[Core] No valid address record cache found. Performing first-time scan.");

            var scannerWatch = Stopwatch.StartNew();
            Parallel.ForEach(addressRecords, (AddressRecordJson record) =>
            {
                var scanner = new AddressRecord(record.Pattern, record.Offset);
                Records.TryAdd(record.Name, scanner.Address);
            });
            scannerWatch.Stop();

            Log.Debug($"[Core] Scanning for addresses took {scannerWatch.ElapsedMilliseconds}ms");

            // Write cache file
            var cacheJson = JsonSerializer.Serialize(
                new AddressRecordCacheJson
                {
                    Version = gameVersion,
                    AddressRecordFileHash = addressRecordFileHash,
                    Addresses = Records.ToDictionary(e => e.Key, e => (ulong)e.Value),
            }) ?? throw new Exception("Failed to deserialize address records cache");

            File.WriteAllText(AddressCachePath, cacheJson);
        }

        private static void LoadPluginRecords()
        {
            if (!File.Exists(PluginCachePath))
                return;

            using var fs = File.OpenRead(PluginCachePath);
            var pluginCache = JsonSerializer.Deserialize<PluginRecordCacheJson>(fs, SerializerOptions)
                ?? throw new Exception("Failed to deserialize plugin records cache");

            var gameVersion = InternalCalls.GetGameRevision();
            if (string.IsNullOrEmpty(gameVersion))
            {
                Log.Error("Failed to get game revision");
                return;
            }

            if (pluginCache.Version == gameVersion)
            {
                Log.Debug("[Core] Restoring from plugin record cache.");

                foreach (var record in pluginCache.Addresses)
                {
                    PluginRecords[record.Key] = (nint)record.Value;
                }

                return;
            }
            
            // Actual scanning will be performed by the plugins themselves.
            Log.Debug("[Core] No valid plugin record cache found. Performing first-time scan.");
        }

        public static void SavePluginRecords()
        {
            var gameVersion = InternalCalls.GetGameRevision();
            if (string.IsNullOrEmpty(gameVersion))
            {
                Log.Error("Failed to get game revision");
                return;
            }

            var cacheJson = JsonSerializer.Serialize(
                new PluginRecordCacheJson
                {
                    Version = gameVersion,
                    Addresses = PluginRecords.ToDictionary(e => e.Key, e => (ulong)e.Value),
                }) ?? throw new Exception("Failed to serialize plugin records cache");

            File.WriteAllText(PluginCachePath, cacheJson);
        }

        public static nint Get(string name)
        {
           if (Records.TryGetValue(name, out var record)) 
               return record;

           throw new Exception($"Failed to find address for {name}");
        }

        public static IDictionary<string, nint> GetPluginRecords() => PluginRecords;

        private static readonly ConcurrentDictionary<string, nint> PluginRecords = [];
        private static readonly ConcurrentDictionary<string, nint> Records = [];

        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
    }
}
