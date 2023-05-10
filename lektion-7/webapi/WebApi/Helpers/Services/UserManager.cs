using System.Linq.Expressions;
using WebApi.Helpers.Repositories;
using WebApi.Migrations;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services;

public class UserManager
{
    #region constructors and private fields

    private readonly UserRepository _userRepo;

    public UserManager(UserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    #endregion


    public async Task<bool> CheckUserExistsAsync(Expression<Func<UserEntity, bool>> expression)
    {
        return await _userRepo.AnyAsync(expression);
    }


    public async Task<bool> CreateAsync(UserEntity user, string password)
    {
        if (!await _userRepo.AnyAsync(x => x.Email == user.Email))
        {
            user.Id = Guid.NewGuid();
            user.GenerateSecurePassword(password);
            await _userRepo.AddAsync(user);

            if (await _userRepo.AnyAsync(x => x.Email == user.Email))
                return true;
        }

        return false;
    }


    public async Task<string> LoginAsync(string email, string password)
    {
        var entity = await _userRepo.GetAsync(x => x.Email == email);
        if (entity != null)
            if (entity.ValidateSecurePassword(password))
                return TokenGenerator.GenerateJwtToken(entity);

        return null!;
    }
}
