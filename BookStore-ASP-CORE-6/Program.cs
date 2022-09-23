using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;

var builder = WebApplication.CreateBuilder(args);
string userDbConnectionString = builder.Configuration["ConnectionStrings:UserDbConnection"];
string bookStoreDbConnectionString = builder.Configuration["ConnectionStrings:BookDbConnection"];
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlite(userDbConnectionString));
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(bookStoreDbConnectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AuthenticationContext>();
//builder.Services.AddAuthentication()
//   .AddGoogle(options =>
//   {
//       IConfigurationSection googleAuthNSection =
//       config.GetSection("Authentication:Google");
//       options.ClientId = googleAuthNSection["ClientId"];
//       options.ClientSecret = googleAuthNSection["ClientSecret"];
//   })
//    .AddFacebook(options =>
//    {
//        IConfigurationSection FBAuthNSection =
//        config.GetSection("Authentication:FB");
//        options.ClientId = FBAuthNSection["ClientId"];
//        options.ClientSecret = FBAuthNSection["ClientSecret"];
//    });
var app = builder.Build();
app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

using (var scope = app.Services.CreateScope())
{
    var userCtx = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    var bookCtx = scope.ServiceProvider.GetRequiredService<DataContext>();
    userCtx.Database.EnsureDeleted();
    bookCtx.Database.EnsureDeleted();
    userCtx.Database.EnsureCreated();
    bookCtx.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
