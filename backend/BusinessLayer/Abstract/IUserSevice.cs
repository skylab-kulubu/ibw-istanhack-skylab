using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IUserService : IGenericService<User>
{
    public IDataResult<User> GetUserByEmail(string email);
}