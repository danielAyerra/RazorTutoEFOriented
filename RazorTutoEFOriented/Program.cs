using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorTutoEFOriented.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<SchoolContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SchoolContext") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}
else
{
    builder.Services.AddDbContext<SchoolContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("SchoolContext"),
            new MySqlServerVersion(new Version(11, 4, 5))
        )
    );
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    if (app.Environment.IsDevelopment())
    {
        var context = services.GetRequiredService<SchoolContext>();
        //This is nice when the project is beggining or at development environment.
        //However, you don't want your database droppend and restarted on production.
        //Believe me. You don't.
        //context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
    }
    else
    {
        //This is actually pointless, unless you have some data to initialize production.
        //Anyways...This project is for learning purposes...
        var context = services.GetRequiredService<SchoolContextMariaDb>();
        DbInitializerMariaDb.Initialize(context);
    }

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();