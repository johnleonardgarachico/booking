using TripBooking.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UsersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // For Container Testing Purpose: Put this back when live
    /*app.UseSwagger();
    app.UseSwaggerUI();*/
}

// Remove on Live
app.UseSwagger();
app.UseSwaggerUI();
// Remove on Live

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
