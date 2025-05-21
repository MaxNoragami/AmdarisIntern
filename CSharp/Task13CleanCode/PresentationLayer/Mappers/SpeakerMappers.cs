using BusinessLayer.Entities;
using Microsoft.AspNetCore.Http;
using PresentationLayer.Dtos;

namespace PresentationLayer.Mappers;

public static class SpeakerMappers
{
    public static Speaker ToSpeaker(this SpeakerDto speakerDto)
    {
        return new Speaker
        {
            FirstName = speakerDto.FirstName,
            LastName = speakerDto.LastName,
            Email = speakerDto.Email,
            Experience = speakerDto.Experience,
            HasBlog = speakerDto.HasBlog,
            BlogURL = speakerDto.BlogURL,
            Browser = speakerDto.Browser?.ToWebBrowser(),
            Certifications = speakerDto.Certifications,
            Employer = speakerDto.Employer,
            Sessions = speakerDto.Sessions.Select(s => new Session(s.Title, s.Description)).ToList()
        };
    }
}
