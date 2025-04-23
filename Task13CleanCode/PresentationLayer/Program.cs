using BusinessLayer.Extensions;
using BusinessLayer.Interfaces;
using BusinessLayer.Entities;
using PresentationLayer.Dtos;
using PresentationLayer.Mappers;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the DI / IoC container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSpeakerRegistration();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.IncludeFields = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// We use either SL or DI to resolve the services and use them in our app

app.MapPost("/speakers", ([FromBody] SpeakerDto speakerDto, [FromServices] ISpeakerRegistration speakerRegistration) =>
{
    try
    {
        var speaker = speakerDto.ToSpeaker();
        var speakerId = speakerRegistration.Register(speaker);
        return Results.Created("/speakers", new { Id = speakerId });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { Error = ex.Message });
    }
});

app.MapGet("/speakers", (IServiceProvider serviceProvider) =>
{
    try
    {
        var repository = serviceProvider.GetRequiredService<IRepository>();
        if (repository is ListRepository listRepository)
            return Results.Ok(listRepository.GetAllSpeakers());
        return Results.NotFound(new { Error = $"Could not find {nameof(repository)}." });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { Error = ex.Message });
    }
});

app.Run();

