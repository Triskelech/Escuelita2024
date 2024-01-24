using Model.Context;
using Model.Entities;
using Service.Contracts;

namespace Service.Services
{
    public class EntityService : IEntityService
    {
        private EscuelitaContext _context;

        public EntityService(EscuelitaContext context)
        {
            _context = context;
        }

        public EscuelitaContext Context
        {
            get { return _context; }
        }

        public IQueryable<T> AsQueryable<T>() where T : Entity
        {
            return Context.Set<T>().AsQueryable();
        }

        public T? Load<T>(int id) where T : Entity
        {
            return Context.Set<T>().SingleOrDefault(a => a.Id == id);
        }

        public void Save<T>(T entity) where T : Entity
        {
            if (entity.Id == 0)
            {
                Context.Set<T>().Add(entity);
            }
            else
            {
                Context.Set<T>().Update(entity);
            }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void SaveAndFlush<T>(T entity) where T : Entity
        {
            Save(entity);
            SaveChanges();
        }

        public void Delete<T>(int id) where T : Entity
        {
            var entity = Load<T>(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        public void Delete<T>(T entity) where T : Entity
        {
            Context.Set<T>().Remove(entity);
        }

        public void DeleteAndFlush<T>(int id) where T : Entity
        {
            Delete<T>(id);
            SaveChanges();
        }

        public void DeleteAndFlush<T>(T entity) where T : Entity
        {
            Delete(entity);
            SaveChanges();
        }
    }
}
