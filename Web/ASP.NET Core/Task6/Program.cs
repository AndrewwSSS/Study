using Microsoft.Extensions.Primitives;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Task1

//app.Run(async (context) => await context.Response.WriteAsync("Current day of year: " + DateTime.Now.DayOfYear.ToString()));
//app.Run();


//Task2

//var random = new Random();
//char letter;

//var b = random.Next(0, 2);

//if (b == 0)
//    letter = (char)random.Next('\u0041', '\u005A');
//else
//    letter = (char)random.Next('\u0061', '\u007A');

//app.Run(async (context) => await context.Response.WriteAsync(letter.ToString()));
//app.Run();


//Task3


//app.Run(async (contex) =>
//{
//    var path = contex.Request.Path;
//    contex.Response.ContentType = "text/html; charset=utf-8";
//    StringBuilder contentBuilder = new();

//    if (path == "/restaurant") {
//        contentBuilder.Append("<h1>Restaurant1</h1>");
//        contentBuilder.Append("<h1>Location: London</h1>");
//        contentBuilder.Append("<h1>Status: Open</h1>");
//    }
//    else {
//        contentBuilder.Append("<ul>");
//        contentBuilder.Append("<li style=\"width:100px;border:1px solid #000;text-align:center;font-size:20px;display:inline-block;padding:10px;\"><a href=\"/restaurant\" style=\"text-decoration:none;\">Restourant</a></li>");
//        contentBuilder.Append("</ul>");
//    }

//    await contex.Response.WriteAsync(contentBuilder.ToString());
//});

//app.Run();



//List<Restaurant> Restaurants = new()
//{
//    new Restaurant(1, "Rest1", "Loc1"),
//    new Restaurant(2, "Rest2", "Loc2")
//};

//app.Run(async (contex) =>
//{
//    var path = contex.Request.Path;
//    contex.Response.ContentType = "text/html; charset=utf-8";
//    StringBuilder contentBuilder = new();



//    if (contex.Request.Query.ContainsKey("id")) {

//        StringValues tmp = contex.Request.Query["id"];
//        int restId = int.Parse(tmp[0]);
//        var rest = Restaurants.FirstOrDefault(r => r.Id == restId);

//        if(rest != null) {
//            contentBuilder.Append($"<h1>{rest.Name}</h1>");
//            contentBuilder.Append($"<h1>Location:{rest.Location}</h1>");
//        }
//        else {
//            contex.Response.StatusCode = 404;
//            contentBuilder.Append("<h1>Not found</h1>");
//        }

//    }
//    else if (path == "/restaurants")
//    {
//        contentBuilder.Append("<ul style=\"list-style: none;\">");
//        foreach(var rest in Restaurants)
//        {
//            contentBuilder.Append($"<li style=\"width:100px;border:1px solid #000;text-align:center;font-size:20px;padding:10px; margin-bottom:10px;\"><a href=\"/restourant/?id={rest.Id}\" style=\"text-decoration:none;\">{rest.Name}</a></li>");
//        }

//        contentBuilder.Append("</ul>");
//    }
//    else
//    {
//        contentBuilder.Append("<ul style=\"list-style: none;\">");

//        contentBuilder.Append($"<li style=\"width:100px;border:1px solid #000;text-align:center;font-size:20px;padding:10px;\"><a href=\"/restaurants\" style=\"text-decoration:none;\">Restaurants</a></li>");

//        contentBuilder.Append("</ul>");
//    }



//    await contex.Response.WriteAsync(contentBuilder.ToString());
//});

//app.Run();


List<Country> Countries = new()
{
    new Country(1, "Country1", 4000000),
    new Country(2, "Country2", 11111111)
};

app.Run(async (contex) =>
{
    var path = contex.Request.Path;
    contex.Response.ContentType = "text/html; charset=utf-8";
    StringBuilder contentBuilder = new();



    if (path == "/Countries" && contex.Request.Query.ContainsKey("id"))
    {

        StringValues tmp = contex.Request.Query["id"];
        int countryId = int.Parse(tmp[0]);
        var country = Countries.FirstOrDefault(r => r.Id == countryId);

        if (country != null)
        {
            contentBuilder.Append($"<h1>{country.Name}</h1>");
            contentBuilder.Append($"<h1>Population:{country.Population}</h1>");
        }
        else
        {
            contex.Response.StatusCode = 404;
            contentBuilder.Append("<h1>Not found</h1>");
        }

    }
    else if (path == "/Countries")
    {
        contentBuilder.Append("<ul style=\"list-style: none;\">");
        foreach (var country in Countries)
        {
            contentBuilder.Append($"<li style=\"width:100px;border:1px solid #000;text-align:center;font-size:20px;padding:10px; margin-bottom:10px;\"><a href=\"/Countries?id={country.Id}\" style=\"text-decoration:none;\">{country.Name}</a></li>");
        }

        contentBuilder.Append("</ul>");
    }
    else
    {
        contentBuilder.Append("<ul style=\"list-style: none;\">");

        contentBuilder.Append($"<li style=\"width:100px;border:1px solid #000;text-align:center;font-size:20px;padding:10px;\"><a href=\"/Countries\" style=\"text-decoration:none;\">Countries</a></li>");

        contentBuilder.Append("</ul>");
    }



    await contex.Response.WriteAsync(contentBuilder.ToString());
});

app.Run();


class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public Restaurant(int id, string name, string location)
    {
        Id = id;
        Name = name;
        Location = location;
    }
}



class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Population { get; set; }
    public Country(int id, string name, int population)
    {
        Id = id;
        Name = name;
        Population = population;
    }
}