var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();


app.MapGet("/Employee", () =>
{
      return "Reading all employee from Service A";
});

app.MapGet("/Employee/{id}", (int id) =>
{
      return $"Reading employee from Service A with ID : {id}";
});

app.MapPost("/Employee/name", (string name) =>
{
      return $"Creating employee from Service A with name : {name}";
});

app.Run();
