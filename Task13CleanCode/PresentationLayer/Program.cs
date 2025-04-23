using BusinessLayer.Extensions;
using BusinessLayer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI / IoC container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSpeakerRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// We use either SL or DI to resolve the services and use them in our app

app.MapGet("/di", (SpeakerRegistration speakerRegistration) =>
{
    speakerRegistration.Register
});


app.Run();

