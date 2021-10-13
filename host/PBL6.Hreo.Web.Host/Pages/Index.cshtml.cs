using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace PBL6.Hreo.Pages
{
    public class IndexModel : HreoPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}