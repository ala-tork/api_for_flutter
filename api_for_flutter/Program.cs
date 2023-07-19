using api_for_flutter.Data;
using api_for_flutter.Services.AdsFeatureSerices;
using api_for_flutter.Services.AdsServices;
using api_for_flutter.Services.CategoryServices;
using api_for_flutter.Services.CitiesServices;
using api_for_flutter.Services.CountryServices;
using api_for_flutter.Services.FeatuesServices;
using api_for_flutter.Services.FeatureValueServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
