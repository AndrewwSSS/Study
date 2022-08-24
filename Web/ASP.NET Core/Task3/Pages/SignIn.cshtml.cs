using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task3.Entities;

namespace Task3.Pages
{

    [IgnoreAntiforgeryToken]
    public class SignInModel : PageModel
    {
        public Rozetka2Context Context { get; set; }


        public SignInModel(Rozetka2Context context) {
            Context = context;
        }

        public IActionResult OnPost(User user)
        {
            if(user.Login != null && user.Password != null)
            {
                User? tmp = Context.Users.FirstOrDefault(u => (u.Login == user.Login || u.Login == user.Mail) && u.Password == user.Password);
                if(tmp != null) {
                    Console.WriteLine("Success");
                    return RedirectToPage("Index");

                }
                else {
                    Console.WriteLine("Denied");
                }

           
            }
            return RedirectToPage();

        }
    }
}
