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
        public void OnGet()
        {
            User user = new User();
            user.Name = User.Identity.Name;
            user.Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            user.ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value;
        }
    }
}
