using Lab.ContextModels;
using Lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab.Pages
{
    public class StergereStireModel : PageModel
    {
        private readonly ILogger<StergereStireModel> _logger;
        private readonly StiriContext _stiriContext;

        public IEnumerable<Stire> Stiri { get; set; }

        public StergereStireModel(ILogger<StergereStireModel> logger, StiriContext stiriContext)
        {
            _logger = logger;
            _stiriContext = stiriContext;
        }

        public async Task<IActionResult> OnGetAsync(int stireId)
        {
            await _stiriContext.Stiri.Where(x => x.Id == stireId).ExecuteDeleteAsync();

            return RedirectToPage("Index");
        }
    }
}
