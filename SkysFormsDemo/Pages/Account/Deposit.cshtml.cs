using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkysFormsDemo.Services;

namespace SkysFormsDemo.Pages.Account
{
    public class DepositModel : PageModel
    {
        private readonly IAccountService _accountService;
        public int Amount { get; set; }

        public DateTime DateWhen { get; set; }

        public string Comment { get; set; }

        public DepositModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void OnGet(int accountId)
        {
            DateWhen = DateTime.Now.AddDays(1).Date;
            Amount = 100;
        }

        public void OnPost(int accountId)
        {
            
            //Hämta account från databasen
            //balance += Amount
            //hoppa tillbaka till kontolistan
        }

    }
}
