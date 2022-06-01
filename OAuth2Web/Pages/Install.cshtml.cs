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

        public async Task<ActionResult> OnPostAsync()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return Page();
            }
            return Page();
        }

        public async Task<ActionResult> OnGetAsync()
        {
            bool needsInstall = await _checker.NeedsInstall();
            if (!needsInstall) return RedirectToPage("Index");
            return Page();
        }
    }
}