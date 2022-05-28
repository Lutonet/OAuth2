using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using OAuth2DataAccess.DataAccess;

namespace OAuth2Web.Pages
{
    public class InstallModel : PageModel
    {
        private IChecksData _checker;
        public IStringLocalizer<InstallModel> _loc { get; set; }

        public InstallModel(IChecksData checker, IStringLocalizer<InstallModel> loc)
        {
            _checker = checker;
            _loc = loc;
        }

        public async Task<ActionResult> OnGetAsync()
        {
            bool needsInstall = await _checker.NeedsInstall();
            if (!needsInstall) return RedirectToPage("Index");
            return Page();
        }
    }
}