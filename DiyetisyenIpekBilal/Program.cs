using DiyetisyenIpekBilal.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DytIpekBilalDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.Configure<Microsoft.AspNetCore.Mvc.CookieTempDataProviderOptions>(options =>//sonradan gelen ayar
{
    options.Cookie.IsEssential = true;
});


builder.Services.Configure<CookiePolicyOptions>(options =>//bunlar sonradan eklendi authonticaton ve autorization işlemleri için 
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>//sonradan gelen ayar
{
    options.LoginPath = "/Hesap/Giris";//yetkisi olmadığı bir yere girerse girişe yönlendirir
    options.AccessDeniedPath = "/Hesap/Giris";//girebildiği ama yetkisi yok ise girişe atacak
    options.LogoutPath = "/Hesap/Giris";//çıkış yapınca da girişe atacak

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();//sonradan gelen ayar
app.UseAuthentication();//sonradan gelne ayar

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
