using Lab.ContextModels;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab.Pages
{
    public class EditeazaStireModel : PageModel
    {
        private readonly ILogger<EditeazaStireModel> _logger;
        private readonly StiriContext _stiriContext;

        [BindProperty]
        public Stire? Stire { get; set; }

        public EditeazaStireModel(ILogger<EditeazaStireModel> logger, StiriContext stiriContext)
        {
            _logger = logger;
            _stiriContext = stiriContext;
        }

        public async Task<IActionResult> OnGetAsync(int stireId)
        {
            Stire = await _stiriContext.Stiri.FirstOrDefaultAsync(s => s.Id == stireId) ?? new Stire();

            if (Stire is null)
            {
                return RedirectToPage("Error");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Stire.Id == default)
            {
                // Create
                Stire.Data = DateTime.UtcNow;

                _stiriContext.Add(Stire);
                await _stiriContext.SaveChangesAsync();
            }
            else
            {
                // Update
                await _stiriContext.Stiri
                    .Where(x => x.Id == Stire.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(x => x.Titlu, Stire.Titlu)
                        .SetProperty(x => x.Autor, Stire.Autor)
                        .SetProperty(x => x.Continut, Stire.Continut)
                        .SetProperty(x => x.Lead, Stire.Lead)
                        .SetProperty(x => x.CategorieId, Stire.CategorieId));
            }

            return RedirectToPage("Index");
        }
    }
}
