using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab.Pages
{
    public class DespreModel : PageModel
    {
        private readonly ILogger<DespreModel> _logger;

        public DespreModel(ILogger<DespreModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
