using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SkysFormsDemo.Data;

public class DataInitializer
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;

    public DataInitializer(ApplicationDbContext dbContext, 
        UserManager<IdentityUser> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public void SeedData()
    {
        _dbContext.Database.Migrate();
        SeedAccounts();
        SeedCountries();
        SeedRoles();
        SeedUsers();
    }


    private void SeedUsers()
    {
        AddUserIfNotExists("stefan.holmberg@systementor.se", "Hejsan123#", new string[] { "Admin" });
        AddUserIfNotExists("stefan.holmberg@customer.systementor.se", "Hejsan123#", new string[] { "Customer" });
    }


    private void SeedRoles()
    {
        AddRoleIfNotExisting("Admin");
        AddRoleIfNotExisting("Customer");
    }


    private void AddRoleIfNotExisting(string roleName)
    {
        var role = _dbContext.Roles.FirstOrDefault(r => r.Name == roleName);
        if (role == null)
        {
            _dbContext.Roles.Add(new IdentityRole { Name = roleName, NormalizedName = roleName });
            _dbContext.SaveChanges();
        }
    }


    private void AddUserIfNotExists(string userName, string password, string[] roles)
    {
        if (_userManager.FindByEmailAsync(userName).Result != null) return;

        var user = new IdentityUser
        {
            UserName = userName,
            Email = userName,
            EmailConfirmed = true
        };
        _userManager.CreateAsync(user, password).Wait();
        _userManager.AddToRolesAsync(user, roles).Wait();
    }



    private void SeedCountries()
    {
        AddCountryIfNotExists("FI", "Finland");
        AddCountryIfNotExists("SE", "Sverige");
        AddCountryIfNotExists("DK", "Danmark");
        AddCountryIfNotExists("NO", "Norge");
    }

    private void AddCountryIfNotExists(string code, string namn)
    {
        if (_dbContext.Countries.Any(r => r.CountryCode == code)) return;
        _dbContext.Countries.Add(new Country {CountryCode = code, Name = namn});
        _dbContext.SaveChanges();
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