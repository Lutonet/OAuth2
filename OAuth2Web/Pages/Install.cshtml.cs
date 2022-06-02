using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using OAuth2DataAccess.DataAccess;
using OAuth2Identity.Services;

namespace OAuth2Web.Pages
{
    public class InstallModel : PageModel
    {
        private IChecksData _checker;
        private IUserService _userService;
        public IStringLocalizer<InstallModel> _loc { get; set; }

        public InstallModel(IChecksData checker,
            IStringLocalizer<InstallModel> loc,
            IUserService userService)
        {
            _checker = checker;
            _loc = loc;
            _userService = userService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];
            if (await _userService.CheckEmail(email) || _userService.CheckPassword(password))
            {
                Console.WriteLine("All good");
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