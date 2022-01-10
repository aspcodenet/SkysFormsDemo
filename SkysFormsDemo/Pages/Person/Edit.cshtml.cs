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
    public class EditModel : PageModel
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


        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int personId)
        {
            var person = _context.Person.First(u=>u.Id == personId );
            Name = person.Name;
            CarCount = person.CarCount;
            City = person.City;
            CountryCode = person.CountryCode;
            Email = person.Email;
            PostalCode = person.PostalCode;
            Salary = person.Salary;
            StreetAddress = person.StreetAddress;
        }


        public IActionResult OnPost(int personId)
        {
            if (ModelState.IsValid)
            {
                var person = _context.Person.First(u=>u.Id == personId);
                person.Name = Name;
                person.CarCount = CarCount;
                person.City = City;
                person.CountryCode = CountryCode;
                person.Email = Email;
                person.PostalCode = PostalCode;
                person.Salary = Salary;
                person.StreetAddress = StreetAddress;
                _context.SaveChanges();
                return RedirectToPage("Index");
            }

            return Page();
        }


    }
}
