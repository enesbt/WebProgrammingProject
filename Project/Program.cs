using BusinessLayer.AddServices;
using DataAccessLayer.AddServices;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDalServices(builder.Configuration);
builder.Services.AddBlServices();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
	x.Password.RequiredLength = 2;
	x.Password.RequireNonAlphanumeric = false;
	x.Password.RequireLowercase = false;
	x.Password.RequireUppercase = false;
	x.Password.RequireDigit = false;
}).AddEntityFrameworkStores<ProjectDbContext>().AddDefaultTokenProviders();


/*builder.Services.ConfigureApplicationCookie(_ =>
{
    _.LoginPath = new PathString("/Login/Index");
    _.LogoutPath = new PathString("/Login/SignOut");
    _.Cookie = new CookieBuilder
    {
        Name = "AspNetCoreIdentityExampleCookie", //Olu�turulacak Cookie'yi isimlendiriyoruz.
        HttpOnly = false, //K�t� niyetli insanlar�n client-side taraf�ndan Cookie'ye eri�mesini engelliyoruz.
        //Expiration = TimeSpan.FromMinutes(20), //Olu�turulacak Cookie'nin vadesini belirliyoruz.
        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin g�nderilmemesini belirtiyoruz.
        SecurePolicy = CookieSecurePolicy.Always //HTTPS �zerinden eri�ilebilir yap�yoruz.
    };
    _.SlidingExpiration = true; //Expiration s�resinin yar�s� kadar s�re zarf�nda istekte bulunulursa e�er geri kalan yar�s�n� tekrar s�f�rlayarak ilk ayarlanan s�reyi tazeleyecektir.
    _.ExpireTimeSpan = TimeSpan.FromMinutes(2); //CookieBuilder nesnesinde tan�mlanan Expiration de�erinin varsay�lan de�erlerle ezilme ihtimaline kar��n tekrardan Cookie vadesi burada da belirtiliyor.
    _.AccessDeniedPath = new PathString("/authority/page");
});*/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/ErrorPage/Index404", "?code{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
