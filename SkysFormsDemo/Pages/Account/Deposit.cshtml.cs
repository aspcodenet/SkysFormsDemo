using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SkysFormsDemo.Pages.Account
{
    public class DepositModel : PageModel
    {
        public int Amount { get; set; }

        public DateTime DateWhen { get; set; }

        public string Comment { get; set; }

        public void OnGet(int accountId)
        {
        }
    }
}
