using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class UserManager : IUserService
{
    private IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IDataResult<User> GetById(int id)
    {
        var user = _userDal.GetById(user => user.userId == id);

        if (user == null)
        {
            return new ErrorDataResult<User>(UserMessages.UserNotFound);
        }

        return new SuccessDataResult<User>(user,UserMessages.UserBroughtSuccessfully);
        //needs some refactoring in every manager, remember!
    }

    public IDataResult<List<User>> GetAll()
    {
        return new SuccessDataResult<List<User>>(UserMessages.UsersBroughtSuccessfully);
        //needs some refactoring in every manager, remember!
    }

    public IResult Add(User p)
    {
        var emailResult = CheckIfEmailExists(p.email);
        if (emailResult.Success)
        {
            return new ErrorResult(emailResult.Message);
        }

        _userDal.Insert(p);

        return new SuccessResult(UserMessages.UserAddedSuccessfully);
    }

    public IResult Update(User p)
    {
        var userResult = GetById(p.userId);
        if (!userResult.Success)
        {
            return userResult;
        }

        _userDal.Update(p);

        return new SuccessResult(UserMessages.UserUpdatedSuccessfully);
    }

    public IResult Delete(int id)
    {
        var userResult = GetById(id);
        if (!userResult.Success)
        {
            return userResult;
        }

        _userDal.Delete(userResult.Data.userId);

        return new SuccessResult(UserMessages.UserDeletedSuccessfully);
    }

    private IResult CheckIfEmailExists(string email)
    {
        var result = _userDal.GetById(user => user.email == email);

        if (result == null)
        {
            return new ErrorResult(UserMessages.UserNotFound);
        }

        return new SuccessResult(UserMessages.EmailAlreadyExists);
    }

    private IResult CheckIfUserExists(int userID)
    {
        var result = _userDal.GetById(user => user.userId == userID);

        if (result == null)
        {
            return new ErrorResult(UserMessages.UserNotFound);
        }

        return new SuccessResult(UserMessages.UserAlreadyExists);
    }

    public IDataResult<User> GetUserByEmail(string email)
    {
        var user = _userDal.GetById(user => user.email == email);

        if (user == null)
        {
            return new ErrorDataResult<User>(UserMessages.UserNotFound);
        }

        return new SuccessDataResult<User>(UserMessages.UserBroughtSuccessfully);
    }
}