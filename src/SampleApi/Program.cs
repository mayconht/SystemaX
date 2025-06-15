var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // This registers the controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7001;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
app.UseHttpsRedirection();

// Add this line to enable CORS if needed
// app.UseCors();

app.UseAuthorization();

// Ensure this line is present to map controller endpoints
app.MapControllers();

var addresses = app.Urls.Count > 0 ? app.Urls : new[] { "https://localhost:7001" };

foreach (var address in addresses)
{
    Console.WriteLine($"Swagger UI: {address}/swagger");
}

app.Run();

// Make Program class public for testing
public partial class Program { }