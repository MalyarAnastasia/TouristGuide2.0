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
            Name = "������",
            Region = "����������� ����������� �����",
            Population = 12600000,
            History = "������� ������, �������� � 1147 ����.",
            CoatUrl = "/images/moscow-coat.png",
            PhotoUrl = "/images/moscow.jpg",
            Attractions = new List<Attraction>
            {
                new Attraction
                {
                    Name = "������� �������",
                    History = "������� ������� ������.",
                    PhotoUrl = "/images/red-square.jpg",
                    WorkingHours = "�������������",
                    Price = null
                },
                new Attraction
                {
                    Name = "������",
                    History = "������������ �������� � ������ ������.",
                    PhotoUrl = "/images/kremlin.jpg",
                    WorkingHours = "10:00 - 18:00",
                    Price = 500
                }
            }
        };

        var saintPetersburg = new City
        {
            Name = "�����-���������",
            Region = "������-�������� ����������� �����",
            Population = 5380000,
            History = "������� ������ I � 1703 ���� ��� ������� ���������� �������.",
            CoatUrl = "/images/spb-coat.png",
            PhotoUrl = "/images/spb.jpg",
            Attractions = new List<Attraction>
            {
                new Attraction
                {
                    Name = "�������",
                    History = "���� �� ���������� �������������� ������ ����.",
                    PhotoUrl = "/images/hermitage.jpg",
                    WorkingHours = "10:30 - 18:00",
                    Price = 600
                },
                new Attraction
                {
                    Name = "��������������� ��������",
                    History = "��������, � ������� �������� ������������� ������.",
                    PhotoUrl = "/images/fortress.jpg",
                    WorkingHours = "10:00 - 18:00",
                    Price = 450
                }
            }
        };

        var Vladivostok = new City
        {
            Name = "�����������",
            Region = "���������� ����",
            Population = 600000,
            History = "������� �������� ������� � 2018 �.",
            CoatUrl = "/images/gerb_vlad.jpg",
            PhotoUrl = "/imagesVladivostok.jpg",
            Attractions = new List<Attraction>
            {
                new Attraction
                {
                    Name = "���� ������������ �����",
                    History = "�����, ��� ���������� ����� �����.",
                    PhotoUrl = "/images/Tokarevski.jpg",
                    WorkingHours = "�������������",
                    Price = null
                },
                new Attraction
                {
                    Name = "����� ������� ��������� ����������s",
                    History = "������� ������������ ���� ������.",
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