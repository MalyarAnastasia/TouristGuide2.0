using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cities}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!db.Cities.Any())
    {
        var moscow = new City
        {
            Name = "Москва",
            Region = "Центральный федеральный округ",
            Population = 12600000,
            History = "Столица России, основана в 1147 году.",
            CoatUrl = "/images/moscow-coat.png",
            PhotoUrl = "/images/moscow.jpg",
            Attractions = new List<Attraction>
            {
                new Attraction
                {
                    Name = "Красная площадь",
                    History = "Главная площадь Москвы.",
                    PhotoUrl = "/images/red-square.jpg",
                    WorkingHours = "Круглосуточно",
                    Price = null
                },
                new Attraction
                {
                    Name = "Кремль",
                    History = "Историческая крепость в центре Москвы.",
                    PhotoUrl = "/images/kremlin.jpg",
                    WorkingHours = "10:00 - 18:00",
                    Price = 500
                }
            }
        };

        var saintPetersburg = new City
        {
            Name = "Санкт-Петербург",
            Region = "Северо-Западный федеральный округ",
            Population = 5380000,
            History = "Основан Петром I в 1703 году как столица Российской империи.",
            CoatUrl = "/images/spb-coat.png",
            PhotoUrl = "/images/spb.jpg",
            Attractions = new List<Attraction>
            {
                new Attraction
                {
                    Name = "Эрмитаж",
                    History = "Один из крупнейших художественных музеев мира.",
                    PhotoUrl = "/images/hermitage.jpg",
                    WorkingHours = "10:30 - 18:00",
                    Price = 600
                },
                new Attraction
                {
                    Name = "Петропавловская крепость",
                    History = "Крепость, с которой началось строительство города.",
                    PhotoUrl = "/images/fortress.jpg",
                    WorkingHours = "10:00 - 18:00",
                    Price = 450
                }
            }
        };

        var Vladivostok = new City
        {
            Name = "Владивосток",
            Region = "Приморский край",
            Population = 600000,
            History = "Столица Дальнего востока с 2018 г.",
            CoatUrl = "/images/gerb_vlad.jpg",
            PhotoUrl = "/imagesVladivostok.jpg",
            Attractions = new List<Attraction>
            {
                new Attraction
                {
                    Name = "Маяк «Токаревская кошка»",
                    History = "Точка, где начинается Тихий океан.",
                    PhotoUrl = "/images/Tokarevski.jpg",
                    WorkingHours = "Круглосуточно",
                    Price = null
                },
                new Attraction
                {
                    Name = "Собор Покрова Пресвятой Богородицыs",
                    History = "Главный православный храм города.",
                    PhotoUrl = "/images/Sobor.jpg",
                    WorkingHours = "9:00 - 18:00",
                    Price = null
                }
            }
        };

        db.Cities.AddRange(moscow, saintPetersburg, Vladivostok);
        db.SaveChanges();
    }
}

app.Run();