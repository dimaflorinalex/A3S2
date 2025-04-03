using Lab.ContextModels;
using Lab.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StiriContext _stiriContext;

        public IEnumerable<Stire> Stiri { get; set; }

        public IndexModel(ILogger<IndexModel> logger, StiriContext stiriContext)
        {
            _logger = logger;
            _stiriContext = stiriContext;
        }

        public async Task OnGetAsync()
        {
            Stiri = await _stiriContext.Stiri.Include(s => s.Categorie).ToArrayAsync();
        }
    }
}
