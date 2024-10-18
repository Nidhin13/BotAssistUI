using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace BotAssistUI.Pages
{
    [BindProperties]
    public class ChatWindowModel : PageModel
    {
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return Page();
        }

    }
}
