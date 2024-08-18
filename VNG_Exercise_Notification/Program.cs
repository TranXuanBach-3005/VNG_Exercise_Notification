using SlimMessageBus.Host;
using SlimMessageBus.Host.Memory;
using System.Reflection;
using VNG_Exercise_Notification.Models;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(assembly));

builder.Services.AddMemoryCache();

builder.Services.AddSingleton(p =>
{
    var users = new List<User>()
            {
                new User() {
                    Id = new Guid("8042B6B0-D99C-484A-AF33-0BD9C6AC59FE"),
                    Name = "Bach1",
                    FollowerIds = new List<Guid>{new Guid("B8098665-32AE-48F3-A04E-C8536ADD4A03"), new Guid("B8098665-32AE-48F3-A04E-C8536ADD4A04")}
                },
                new User() {
                    Id = new Guid("B8098665-32AE-48F3-A04E-C8536ADD4A03"),
                    Name = "Bach2",
                    FollowerIds = new List<Guid> {new Guid("8042B6B0-D99C-484A-AF33-0BD9C6AC59FE") }
                },
                new User() {
                    Id = new Guid("B8098665-32AE-48F3-A04E-C8536ADD4A04"),
                    Name = "Bach3",
                    FollowerIds = new List<Guid> {new Guid("8042B6B0-D99C-484A-AF33-0BD9C6AC59FE") }
                }

            };
    return users;
});


builder.Services.AddSlimMessageBus(mbb =>
           {
               mbb
                  .WithProviderMemory()
                  .AutoDeclareFrom(assembly)
                  .AddServicesFromAssembly(Assembly.GetExecutingAssembly());
           });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
