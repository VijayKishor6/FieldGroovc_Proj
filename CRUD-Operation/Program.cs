using AspNetCoreHero.ToastNotification.Abstractions;
using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using CRUD.Services.Implementation;
using CRUD.Services.Interfaces;
using CRUD.Services.Services;
using CRUD.Services.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
    
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"), b =>
        b.MigrationsAssembly("CRUD.Data.MySQL")));

builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterValidator>());

builder.Services.AddTransient<IValidator<Login>, LoginValidator>();



// Configure the default Identity for IdentityUser
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ProductContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; 
        options.JsonSerializerOptions.DictionaryKeyPolicy = null; 
    });


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<ILeadsRepository, LeadsRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEstimatesRepository, EstimatesRepository>();
builder.Services.AddScoped<IOpportunities, OpportunitiesRepository>();
builder.Services.AddScoped<CRUD.Services.Services.LeadsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}
builder.Logging.AddConsole();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Register}/{action=Login}/{id?}");
/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=fieldGroove}/{action=Index}/{id?}");*/

app.Run();
