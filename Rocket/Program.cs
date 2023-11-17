using Rocket.DataAccess;
using Rocket.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IPersonDatabaseAccess, PersonDatabaseAccess>();
builder.Services.AddSingleton<PersonService>();// eine instanz für alle konsumenten
//builder.Services.AddTransient<PersonService>(); // jeder konsument erhält seine eigne instanz
//builder.Services.AddScoped<PersonService>(); // jeder rest call bekommt ein und die selbe instanz

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
