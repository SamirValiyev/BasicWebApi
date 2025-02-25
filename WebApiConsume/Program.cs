using WebApiConsume.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ProductService>();
//builder.WebHost.ConfigureKestrel(options =>
//     options.ListenAnyIP(5240)

//     );
builder.Services.AddScoped<ProductService>();
//builder.Services.AddHttpClient("ProductClient", client =>
//{
//    client.BaseAddress = new Uri("");
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
