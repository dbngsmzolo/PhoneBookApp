using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBookApp.Core.Data.Ef
{
    public class EfRepository<TEntity>
        : IEntityRepository<TEntity>
        where TEntity :
        class,
        IEntity,
        new()
    {
        public TEntity Add(TEntity entity, DbContext context)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
            return addedEntity.Entity;
        }

        public bool Delete(TEntity entity, DbContext context)
        {
            try
            {
                var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, DbContext context)
        {
            return context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetList(DbContext context, Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? context.Set<TEntity>().ToList() 
                    : context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity Update(TEntity entity, DbContext context)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Modified;
            context.SaveChanges();
            return addedEntity.Entity;
        }
    }
}
