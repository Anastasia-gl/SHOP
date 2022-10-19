using Microsoft.EntityFrameworkCore;
using Shop.Context.Model;
using Shop.Domain.Interface.Service;
using Shop.Domain.Interface.Store;
using Shop.Domain.Service;
using Shop.Identity;
using Shop.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ShopContext>(x => x.UseSqlServer(connection));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductStore, Shop.Persistence.ProductStore>();

builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<ITypeStore, TypeStore>();

builder.Services.AddScoped<ICharacteristicService, CharacteristicService>();
builder.Services.AddScoped<ICharacteristicStore, CharacteristicStore>();

builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBasketStore, BasketStore>();

builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IHistoryStore, HistoryStore>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserStore, UserStore>();

builder.Services.AddScoped<IProductBasketService, ProductBasketService>();
builder.Services.AddScoped<IProductBasketStore, ProductBasketStore>();

builder.Services.AddSingleton<JwtToken>();

var service = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
var react = service.GetValue<string>("frontend_url");

builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(react, "http://localhost:7213", "http://localhost:1433").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
