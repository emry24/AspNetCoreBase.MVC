using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AddressRepository(UserDbContext context) : Repo<AddressEntity>(context)
{
    private readonly UserDbContext _context = context;
}