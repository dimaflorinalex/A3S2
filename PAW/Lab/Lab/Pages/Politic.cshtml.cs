using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab.Pages
{
    public class PoliticModel : PageModel
    {
        private readonly ILogger<PoliticModel> _logger;

        public PoliticModel(ILogger<PoliticModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
