using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEntityService
    {
        IQueryable<T> AsQueryable<T>() where T : Entity;

        T? Load<T>(int id) where T : Entity;

        void Save<T>(T entity) where T : Entity;

        void SaveChanges();

        void SaveAndFlush<T>(T entity) where T : Entity;

        void Delete<T>(int id) where T : Entity;

        void Delete<T>(T entity) where T : Entity;
    }
}
