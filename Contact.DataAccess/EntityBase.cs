using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Contact.Core;

using Microsoft.EntityFrameworkCore;

namespace Contact.DataAccess
{
    public class EntityBase<TEntity, TContext> : IEntityRepository<TEntity>
      where TEntity : class, IEntity, new()
      where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {

                //var addedEntity = context.Entry(entity);
                //addedEntity.State = EntityState.Added;


                context.Add(entity);

                context.SaveChanges();
                
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
            }
        }




        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public IQueryable<TEntity> GetQuery()
        {
            var context = new TContext();
            return context.Set<TEntity>().AsQueryable();


        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {

                //var updatedEntity = context.Entry(entity);
                //updatedEntity.State = EntityState.Modified;

               
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}

