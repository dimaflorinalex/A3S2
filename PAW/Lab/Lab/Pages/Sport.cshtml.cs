using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab.Pages
{
    public class SportModel : PageModel
    {
        private readonly ILogger<SportModel> _logger;

        public SportModel(ILogger<SportModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
