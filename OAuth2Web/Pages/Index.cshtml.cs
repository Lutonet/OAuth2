using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OAuth2DataAccess.DataAccess;

namespace OAuth2Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IChecksData _checker;

        public IndexModel(ILogger<IndexModel> logger, IChecksData checker)
        {
            _logger = logger;
            _checker=checker;
        }

        public async Task<ActionResult> OnGetAsync()
        {
            bool needsInstall = await _checker.NeedsInstall();
            if (needsInstall) return RedirectToPage("Install");
            return Page();
        }
    }
}