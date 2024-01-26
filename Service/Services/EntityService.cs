using Model.Context;
using Model.Entities;
using Service.Contracts;

namespace Service.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
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

        public IQueryable<T> AsQueryable()
        {
            return Context.Set<T>().AsQueryable();
        }

        public T? Load(int id)
        {
            return Context.Set<T>().SingleOrDefault(a => a.Id == id);
        }

        public void Save(T entity)
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

        public void SaveAndFlush(T entity)
        {
            Save(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Load(id);

            if (entity != null)
            {
                Delete(entity);
            }
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void DeleteAndFlush(int id)
        {
            Delete(id);
            SaveChanges();
        }

        public void DeleteAndFlush(T entity)
        {
            Delete(entity);
            SaveChanges();
        }
    }
}
