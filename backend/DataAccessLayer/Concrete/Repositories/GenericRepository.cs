using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Repositories;

public class GenericRepository<P> : IGenericDal<P> where P : class, IEntity
{
    DbSet<P> _object;

    public GenericRepository()
    {
        using (var context = new Context.Context())
        {
            _object = context.Set<P>();
        }
    }

    public List<P> GetAll(Expression<Func<P, bool>> filter = null)
    {
        using(var context=new Context.Context())
        {
            return filter == null
                ? context.Set<P>().ToList()
                : context.Set<P>().Where(filter).ToList();
        }
    }

    P IGenericDal<P>.GetById(Expression<Func<P, bool>> filter)
    {
        using (var context = new Context.Context())
        {
            return context.Set<P>().SingleOrDefault(filter);
        }
    }

    void IGenericDal<P>.Insert(P p)
    {
        using (var context = new Context.Context())
        {
            var insertedEntity = context.Entry(p);
            insertedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    void IGenericDal<P>.Update(P p)
    {
        using (var context = new Context.Context())
        {
            var updatedEntity = context.Entry(p);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        using (var context = new Context.Context())
        {
            var deletedEntity = context.Entry(_object.Find(id));
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}