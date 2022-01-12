using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using SkysFormsDemo.Data;
using SkysFormsDemo.Services;

namespace SkysFormsDemo.Pages.Person
{
    [BindProperties]
    public class NewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        
        [StringLength(100)]
        public string StreetAddress { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(2)] public string CountryCode { get; set; }

        [Range(0, 100000, ErrorMessage = "Skriv ett tal mellan 0 och 100000")]
        public decimal Salary { get; set; }


        [Range(0, 100)]
        public int CarCount { get; set; } //Krysta fram ett int-usecase

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        public NewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var person = new Data.Person
                {
                    CarCount = CarCount,
                    StreetAddress = StreetAddress,
                    Email = Email,
                    City = City,
                    //CountryCode = CountryCode, //TODO
                    Salary = Salary,
                    Name = Name,
                    PostalCode = PostalCode,
                    LastModified = DateTime.UtcNow,
                    Registered = DateTime.UtcNow
                };
                _context.Person.Add(person);
                _context.SaveChanges();
                return RedirectToPage("Index");
            }

            return Page();
        }

    }
}
