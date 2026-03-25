using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileStorage
    {
        private readonly string path;

        public FileStorage(string path)
        {
            this.path = path;
        }
        public SchoolStorage Load()
        {
            if (!File.Exists(path))
            {
                return new SchoolStorage();
            }

            var json = File.ReadAllText(path);

            var storage = JsonSerializer.Deserialize<SchoolStorage>(json);
            if (storage == null)
                throw new Exception("Deserialization return null.");

            return storage;

        }
        public void Save(SchoolStorage storage)
        {
            var json = JsonSerializer.Serialize(storage);
            File.WriteAllText(path, json);

        }
    }
}
