using AuthMVC.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



//1�re m�thode pour modifier les options param�tr�es de la configuration de mots de passe
builder.Services.Configure<IdentityOptions>(options =>
{
    //pour d�finir la longueur du password
    options.Password.RequiredLength = 10;
    //pour d�finir le nombre de caract�res uniques
    options.Password.RequiredUniqueChars = 3;
});

////2�me m�thode pour modifier les options param�tr�es de la configuration de mots de passe
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
//{
//    //pour d�finir la longueur du password
//    options.Password.RequiredLength = 12;
//    //pour d�finir le nombre de caract�res uniques
//    options.Password.RequiredUniqueChars = 2;
//}).AddEntityFrameworkStores<ApplicationDbContext>();


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));





builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}








app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
