using System.Linq.Expressions;
using EntityLayer.Abstract;

namespace DataAccessLayer.Abstract;

public interface IGenericDal<P> where P : class, IEntity
{
    List<P> GetAll(Expression<Func<P, bool>> filter = null);
    P GetById(Expression<Func<P, bool>> filter);
    void Insert(P p);
    void Update(P p);
    void Delete(int id);
}