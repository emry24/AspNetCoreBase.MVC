using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;
public class AccountService
{
    private readonly UserDbContext _context;
    private readonly UserManager<UserEntity> _userManager;

    public AccountService(UserDbContext context, UserManager<UserEntity> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    //public async Task<bool> UpdateUserAsync(UserEntity user)
    //{
    //    _context.Users.FirstOrDefaultAsync(user => user.Id == user.Id);

    //    _userManager.Users.FirstOrDefaultAsync(user => user.Email == user.Email);
    //}
}
