using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;

namespace Task1.Pages
{
    public class Index2Model : PageModel
    {


        public string[] Authors = new string[] { "A1", "A2", "A3", "A4" };
        public string[] Quotes = new string[] { "q1", "q2", "q3", "q4" };

        public string random { get
            {
                int index = new Random().Next(0, Authors.Length - 1);
                return Authors[index] + " : " + Quotes[index];
            }
            set
            {
                random = value;
            }
        }
        

        public void OnGet()
        {
           

        }
    }
}
