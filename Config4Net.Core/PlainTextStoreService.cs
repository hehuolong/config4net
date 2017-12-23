﻿using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Config4Net.Core
{
    public sealed class PlainTextStoreService : FileStoreService
    {
        public override Task SaveAsync(string filePath, string content)
        {
            return Task.Run(() =>
            {
                File.WriteAllText(filePath, content, Encoding.UTF8);
            });
        }

        public override Task<string> LoadAsync(string filePath)
        {
            return Task.Run(() => File.ReadAllText(filePath, Encoding.UTF8));
        }
    }
}