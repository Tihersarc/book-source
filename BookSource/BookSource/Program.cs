using BookSource.DAL;

var builder = WebApplication.CreateBuilder(args);

// Simulando el m�todo ConfigureServices
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Simulando el m�todo Configure
Configure(app, app.Environment);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Add services to the container.
    services.AddControllersWithViews();

    // Aqu� puedes agregar m�s configuraciones de servicios, como:
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    //services.AddDbContext<MyDbContext>(options =>
    //     options.UseSqlServer(configuration.GetConnectionString(connectionString)));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UserDAL>(); // Registra UserDAL en el sistema de DI // Asumiendo que UserDAL no depende de otros servicios
builder.Services.AddScoped<BookDAL>();
builder.Services.AddScoped<FollowDAL>();
builder.Services.AddScoped<ListOfBooksDAL>();
builder.Services.AddScoped<CategoriesDAL>();
builder.Services.AddScoped<PublicationDAL>();

builder.Services.AddScoped<ReviewDAL>();
    


    builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

    // Agregar servicios de autenticaci�n, etc.
    // services.AddAuthentication();
}

void Configure(WebApplication app, IWebHostEnvironment env)
{
    // Configure the HTTP request pipeline.
    if (!env.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

app.UseSession();
// app.UseHttpsRedirection();
app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}
