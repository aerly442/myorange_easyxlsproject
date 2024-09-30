using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using my_orange_easyxls.Data;
 
using System.Configuration;
using my_orange_easyxls.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.FileProviders;
using Radzen;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<MyOrangePMPProjectContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Myorange_PMProjectContext_sqlite") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));
 

builder.Services.AddScoped<OrgFileService>();
builder.Services.AddScoped<OrgFieldService>();
builder.Services.AddScoped<XlsFileService>();
builder.Services.AddScoped<OrgDataService>();

////builder.Services.AddScoped<CurrentUserService>();

builder.Services.AddScoped<FileUploadService>();

builder.Services.AddRadzenComponents();

builder.Services.AddHttpClient();

builder.Services.AddControllers();


/*
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)

    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/LoginUser";
        options.LoginPath = "/LoginUser";
    });
*/
/*
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true, //是否验证Issuer
                ValidIssuer = builder.Configuration["Jwt:Issuer"], //发行人Issuer
                ValidateAudience = true, //是否验证Audience
                ValidAudience = builder.Configuration["Jwt:Audience"], //订阅人Audience
                ValidateIssuerSigningKey = true, //是否验证SecurityKey
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])), //SecurityKey
                ValidateLifetime = true, //是否验证失效时间
                ClockSkew = TimeSpan.FromSeconds(30), //过期时间容错值，解决服务器端时间不同步问题（秒）
                RequireExpirationTime = true,
            };
        }
     );

*/


// 添加日志提供者  
builder.Logging.ClearProviders(); // 如果需要的话，先清除默认提供者  
//builder.Logging.AddFilter("Microsoft", LogLevel.Warning); // 设置Microsoft日志的级别  
//builder.Logging.AddFilter("System", LogLevel.Warning);  
builder.Logging.AddFilter("my_orange_easyxls", LogLevel.Information); // 设置你的命名空间或类的日志级别  
  
// 添加控制台日志提供者  
builder.Logging.AddConsole();  

var app = builder.Build();


//使用验证
app.UseAuthentication();
app.UseAuthorization();
//app.UseAuthentication();//身分驗證

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

/*
var image_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image_path");
if (!Directory.Exists(image_path)) Directory.CreateDirectory(image_path);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(image_path),
    RequestPath = "/I"
});
*/
app.UseRouting();

//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");


app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapControllers();
    endpoints.MapFallbackToPage("/_Host");
});

////var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
//using (var scope = scopeFactory.CreateScope())
////{
///var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
//if (db.Database.EnsureCreated())
////{
//   SeedData.Initialize(db);
// }
//}




app.Run();
