using SingletonVsTransientDI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IIDSingleton>(new ID());
builder.Services.AddScoped<IIDScoped, ID>();
builder.Services.AddTransient<IIDTransient, ID>();

var app = builder.Build();

app.MapGet("/now", (IIDSingleton idSingleton,
                    IIDScoped idScoped1, IIDScoped idScoped2,
                    IIDTransient idTransient1, IIDTransient idTransient2) =>
{
    return $"Singleton instance: {idSingleton.Value}\r\n\r\n" +
        $"Scoped instance 1: {idScoped1.Value}\r\nScoped instance 2: {idScoped2.Value}\r\n\r\n" +
        $"Transient instance 1: {idTransient1.Value}\r\nTransient instance 2: {idTransient2.Value}";
});

app.Run();
