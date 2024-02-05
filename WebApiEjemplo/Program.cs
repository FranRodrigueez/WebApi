using WebApi;
using WebApiEjemplo.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


Class1 con = new Class1();
con.connect();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseWebSockets();                            // Aceptar WebSockets
app.Map("/ws", b => {                           //Mapping the ws route
    b.UseMiddleware<MiControladorDeWebSockets>();  // Controlador para WebSockets
});

app.MapControllers();

app.Run();
