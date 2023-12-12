var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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


app.MapGet("/sample1/5", () => "Specific route for id: 5")
   .WithTags("Sample 1");

app.MapGet("/sample1/{id}", (int id) => $"Custom route using the id: {id}")
   .WithTags("Sample 1");

app.MapGet("/sample1/12", () => "Specific route for id: 12")
   .WithTags("Sample 1");


// I wonder what this'll do... (spoiler: not much)

//app.MapGet("/sample2/{id}", (int id) => $"You passed an integer: {id}")
//   .WithTags("Sample 2");

//app.MapGet("/sample2/{id}", (decimal id) => $"You passed a decimal: {id}")
//   .WithTags("Sample 2");

//app.MapGet("/sample2/{id}", (double id) => $"You passed a double: {id}")
//   .WithTags("Sample 2");


app.Run();
