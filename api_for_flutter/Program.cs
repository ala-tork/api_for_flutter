using api_for_flutter.Data;
using api_for_flutter.Services.AdsFeatureSerices;
using api_for_flutter.Services.AdsServices;
using api_for_flutter.Services.BoostServices;
using api_for_flutter.Services.BrandsServices;
using api_for_flutter.Services.CategoryServices;
using api_for_flutter.Services.CitiesServices;
using api_for_flutter.Services.CountryServices;
using api_for_flutter.Services.DealsServices;
using api_for_flutter.Services.FeatuesServices;
using api_for_flutter.Services.FeatureValueServices;
using api_for_flutter.Services.Iimages_Services;
using api_for_flutter.Services.Images_Services;
using api_for_flutter.Services.LikeServices;
using api_for_flutter.Services.WinnersServices;
using api_for_flutter.Services.WishListServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
    s.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    }));
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });

});

//dbconnection
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("localDb")));


builder.Services.AddScoped<Iservices, Service>();

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IFeaturesService, FeaturesService>();
builder.Services.AddScoped<IFeatureValueService, FeatureValueService>();
builder.Services.AddScoped<IAdsFeatureService, AdsFeatureService>();
builder.Services.AddScoped<IImageService, imagesService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IDealsService, DealsService>();
builder.Services.AddScoped<ILikeService,LikeService>();
builder.Services.AddScoped<IWinnerService,WinnersService>();
builder.Services.AddScoped<IWishListService, WishListService>();
builder.Services.AddScoped<IBoostService, BoostService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
DbInitializer.Seed(app);
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
