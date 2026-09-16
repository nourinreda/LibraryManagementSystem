using LibraryManagementSystem.Entity.LibraryManagementSystem.Entity;
using System.Text.Json;

namespace LibraryManagementSystem.Data
{
    internal class DataStorage
    {
        private readonly string filePath;
        public DataStorage()
        {
            filePath = Path.Combine(AppContext.BaseDirectory, "library.json");
        }

        public void Save(Library library)
        {
            if (library == null)
                throw new ArgumentNullException(nameof(library));


            string json = JsonSerializer.Serialize(library);
            File.WriteAllText(filePath, json);
        }
        public Library Load()
        {
            if (!File.Exists(filePath))
            {
                return new Library();
            }
            string json = File.ReadAllText(filePath);
            Library ?library = JsonSerializer.Deserialize<Library>(json);

            return library ?? new Library();
        }
    }
}