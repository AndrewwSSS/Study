using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Pages
{
    public class IndexModel : PageModel
    {
        public string Text = "Hello, World!";
        public DateTime TimeNow = DateTime.Now;
        public IConfigurationRoot AppConfiguration { get; private set; }

        public void OnGet()
        {

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");


            AppConfiguration = builder.Build();
        }
    }
}
