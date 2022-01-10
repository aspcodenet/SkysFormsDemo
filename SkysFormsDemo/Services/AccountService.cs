using System.Collections.Immutable;
using SkysFormsDemo.Data;

namespace SkysFormsDemo.Services;

public class AccountService : IAccountService
{
    private readonly ApplicationDbContext _context;

    public AccountService(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Account> GetAll()
    {
        return _context.Accounts.ToList();
    }
}