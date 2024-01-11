using Invidux_Core.Extensions;
using Invidux_Core.Helpers;
using Invidux_Core.Repository.Implementations;
using Invidux_Core.Repository.Interfaces;
using Invidux_Core.Services;
using Invidux_Data.Context;
using Invidux_Data.Dtos.AutoMapping;
using Invidux_Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordPolicy>();
builder.Services.AddTransient<IUserValidator<AppUser>, CustomUsernamePolicy>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
// Add services to the container.
builder.Services.AddDbContext<InviduxDBContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("LocalDB"),
                    p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                    // .EnableSensitiveDataLogging()
                    , ServiceLifetime.Scoped);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddAutoMapper(typeof(Mapping).Assembly);
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IPhotoService, PhotoService>();

builder.Services.AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = true)
.AddEntityFrameworkStores<InviduxDBContext>()
.AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options => {
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = true;
});

builder.Services.Configure<Sendgrid>(builder.Configuration.GetSection("Sendgrid"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                // services.AddAuthentication("Bearer")
                .AddJwtBearer(opt => {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                    opt.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            // Log or handle authentication failures
                            return Task.CompletedTask;
                        }
                    };
                });

// Remove server name from response header
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
}*/
 app.ConfigureExceptionHandler(app.Environment);
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "Invidux v1"));

app.UseRouting();
app.UseHsts();

app.UseHttpsRedirection();
app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dc = services.GetRequiredService<InviduxDBContext>();
        InviduxDBContext.SeedCountries(dc);
    }
    catch (Exception ex)
    {
        // Log the exception
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
app.Run();
