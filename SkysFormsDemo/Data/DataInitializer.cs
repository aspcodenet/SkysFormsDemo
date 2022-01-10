using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SkysFormsDemo.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _dbContext;

    public DataInitializer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SeedData()
    {
        _dbContext.Database.Migrate();
        SeedAccounts();
    }

    private void SeedAccounts()
    {
        AddAccountIfNotExists("12345");
        AddAccountIfNotExists("55555");
    }

    private void AddAccountIfNotExists(string accountNo)
    {
        if (_dbContext.Accounts.Any(e => e.AccountNo == accountNo)) return;
        _dbContext.Accounts.Add(new Account
        {
            AccountNo = accountNo,
            Balance = 1000
        });
        _dbContext.SaveChanges();
    }
}