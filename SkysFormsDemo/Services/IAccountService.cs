using SkysFormsDemo.Data;

namespace SkysFormsDemo.Services;

public interface IAccountService
{
    public List<Account> GetAll();
}