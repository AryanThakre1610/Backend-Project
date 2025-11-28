using ShooterBackend.Models;

namespace ShooterBackend.Managers
{
    public class Inventory<T> where T : GameEntity
    {
        private List<T> entities = new List<T>();
        private int nextId = 1;

        public void Add(T entity)
        {
            entity.Id = nextId++;
            entities.Add(entity);
            Console.WriteLine($"{entity.GetType().Name} added successfully!");
        }

        public void ViewAll()
        {
            if (!entities.Any())
            {
                Console.WriteLine("No entities found.");
                return;
            }

            foreach (var entity in entities)
                entity.DisplayInfo();
        }

        public void Delete(int id)
        {
            var entity = entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                Console.WriteLine("Entity not found.");
                return;
            }

            entities.Remove(entity);
            Console.WriteLine($"{entity.GetType().Name} deleted successfully!");
        }

        public void Update(int id, T updatedEntity)
        {
            var entity = entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                Console.WriteLine("Entity not found.");
                return;
            }

            updatedEntity.Id = id;
            int index = entities.IndexOf(entity);
            entities[index] = updatedEntity;
            Console.WriteLine($"{updatedEntity.GetType().Name} updated successfully!");
        }

        public List<T> GetAll() => entities;
    }
}
