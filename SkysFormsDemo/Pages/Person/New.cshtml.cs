using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SkysFormsDemo.Services;

namespace SkysFormsDemo.Pages.Person
{
    [BindProperties]
    public class NewModel : PageModel
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(100)]
        public string StreetAddress { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(2)] public string CountryCode { get; set; }

        [Range(0, 100000, ErrorMessage = "Skriv ett tal mellan 0 och 100000")]
        public decimal Salary { get; set; }


        public int CarCount { get; set; } //Krysta fram ett int-usecase

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [StringLength(150)]
        public string Email { get; set; }


        public void OnGet()
        {

        }

    }
}
