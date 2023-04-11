using Microsoft.EntityFrameworkCore;
using TodoList.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionando o DbContext na aplicação e passando o TIPO do Banco e sua ConnectionString
builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>  optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))  );


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();