using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task3.Entities;
namespace Task3.Pages
{
    [IgnoreAntiforgeryToken]
    public class RegistrationModel : PageModel
    {
        public Rozetka2Context Context { get; set; }

        public RegistrationModel(Rozetka2Context context) {
            Context = context;
            
        }

        public void OnPost(User user)  {
             if (!Context.Users.Any(u => u.Mail == user.Mail ||
                                   u.Login == user.Login ||
                                   u.Password == user.Login ||
                                   u.Telephone == user.Telephone))
             { 
                 Context.Users.Add(user);
                 Context.SaveChanges();
             }

   
        }
    }
}
