using Lab.ContextModels;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab.Pages
{
    public class StireModel : PageModel
    {
        private readonly ILogger<StireModel> _logger;
        private readonly StiriContext _stiriContext;

        public Stire? Stire { get; set; }

        public StireModel(ILogger<StireModel> logger, StiriContext stiriContext)
        {
            _logger = logger;
            _stiriContext = stiriContext;
        }

        public async Task<IActionResult> OnGetAsync(int stireId)
        {
            Stire = await _stiriContext.Stiri.Include(s => s.Categorie).FirstOrDefaultAsync(s => s.Id == stireId);

            if (Stire is null)
            {
                return RedirectToPage("Error");
            }

            return Page();
        }
    }
}
