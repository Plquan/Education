using Education.Application.Interfaces;
using Education.Application.Repository;
using Education.Data.EF;
using Education.Data.Entities;
using Education.WebApp.Models;
using Education.WebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<ITutorRepository,TuTorRepository>();
builder.Services.AddScoped<IBookMarkRepository,BookmarkRepository>();
builder.Services.AddScoped<ILikeRepository,LikeRepository>();
builder.Services.AddScoped<ICommentRepository,CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
//cloudinary
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddDbContext<EducationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<EducationDbContext>();

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Password settings.
//    options.Password.RequireDigit = false;
//    options.Password.RequireLowercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireUppercase = false;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;

//    // Lockout settings.
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
//    options.Lockout.MaxFailedAccessAttempts = 10;
//    options.Lockout.AllowedForNewUsers = true;

//    // User settings.
//    options.User.AllowedUserNameCharacters =
//    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//    options.User.RequireUniqueEmail = false;

//    // Cấu hình đăng nhập.
//    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
//    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
//    options.SignIn.RequireConfirmedAccount = true;
//});

builder.Services.ConfigureApplicationCookie(options =>
{ 
    options.AccessDeniedPath = "/Admin/Privacy/Index";
    options.LoginPath = "/Account/Login";
   
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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
