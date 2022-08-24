using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Task2.Pages
{

    public class Country
    {
        public string Name;
        public string Capital;
        public int Population;

        public Country(string name, string capital, int population)
        {
            Name = name;
            Capital = capital;
            Population = population;
        }
    }

    public class Task5Model : PageModel
    {

        public List<Country> Countries = new List<Country>();

        public Task5Model()
        {
            Countries.Add(new Country("Ukraine", "Kiev", 44130000));
            Countries.Add(new Country("Greate Britain", "London", 8878892));
            Countries.Add(new Country("USA", "Washington", 44130000));

        }
        public void OnGet()
        {
        }
    }
}
