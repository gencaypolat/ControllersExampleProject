var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // adds all the Controller class as a service

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();
app.Run();

