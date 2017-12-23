﻿using System.Threading.Tasks;

namespace Config4Net.Core
{
    public interface IStoreService
    {
        Task<string[]> GetEntriesAsync(string configDir, string searchPattern);

        Task SaveAsync(string filePath, string content);

        Task<string> LoadAsync(string filePath);
    }
}