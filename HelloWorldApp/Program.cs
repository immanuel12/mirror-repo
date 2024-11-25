using HelloWorldApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Menambahkan konfigurasi logging
builder.Services.AddLogging(logging =>
{
    logging.AddConsole(); // Menambahkan logging ke konsol
    logging.AddDebug();   // Menambahkan logging ke debug output
});

// Konfigurasi DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Menambahkan layanan untuk controller dan Razor Pages
builder.Services.AddControllers();
builder.Services.AddRazorPages();

var app = builder.Build();

// Konfigurasi middleware
app.UseStaticFiles(); // Untuk mendukung file statis seperti CSS, JS
app.UseRouting();
app.UseAuthorization();

// Tambahkan endpoint untuk Razor Pages dan API
app.MapControllers(); // Untuk API
app.MapRazorPages();   // Untuk Razor Pages

// Menjalankan aplikasi
app.Run();
