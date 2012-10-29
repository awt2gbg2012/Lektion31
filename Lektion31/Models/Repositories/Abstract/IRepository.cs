using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion31.Models.Entities.Abstract;
using System.Data.Entity;

namespace Lektion31.Models.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        DbContext Model { get; }

        IQueryable<T> FindAll(Func<T, bool> filter = null);
        T FindByID(Guid id);
        void Save(T entity);
        void Delete(T entity);

        void Commit();
    }
}