using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TodoWebClient.Pages.Models;

namespace TodoWebClient.Pages.Account
{
    [Authorize]
    public class UserInfoModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public User GetUser { get; set; }
        public void OnGet()
        {
            GetUser.Name = User.Identity.Name;
            GetUser.Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            GetUser.ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value;
            GetUser.Expiration = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Expiration)?.Value;
            GetUser.Authentication = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Authentication)?.Value;
        }
    }
}
