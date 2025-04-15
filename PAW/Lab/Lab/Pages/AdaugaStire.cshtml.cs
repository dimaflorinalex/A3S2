using Lab.ContextModels;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab.Pages
{
    public class AdaugaStireModel : PageModel
    {
        private readonly ILogger<AdaugaStireModel> _logger;
        private readonly StiriContext _stiriContext;

        [BindProperty]
        public Stire Stire { get; set; } = new Stire();

        public AdaugaStireModel(ILogger<AdaugaStireModel> logger, StiriContext stiriContext)
        {
            _logger = logger;
            _stiriContext = stiriContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Stire.Data = DateTime.UtcNow;

            _stiriContext.Add(Stire);
            await _stiriContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
