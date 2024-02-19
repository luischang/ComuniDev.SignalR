using ComuniDev.SignalR.API.RealTime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting(); // Agrega el middleware de enrutamiento

app.UseAuthorization();
app.UseCors();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/chatHub");
});
app.MapControllers();

app.Run();
