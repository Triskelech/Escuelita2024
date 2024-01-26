using Model.Entities;

namespace Service.Contracts
{
    public interface IEntityService<T> where T : Entity
    {
        IQueryable<T> AsQueryable();

        T? Load(int id);

        void Save(T entity);

        void SaveChanges();

        void SaveAndFlush(T entity);

        void Delete(int id);

        void Delete(T entity);
    }
}
