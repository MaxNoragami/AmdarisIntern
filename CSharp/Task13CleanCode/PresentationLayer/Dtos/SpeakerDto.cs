using BusinessLayer.Entities;

namespace PresentationLayer.Dtos;

public class SpeakerDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int? Experience { get; set; }
    public bool HasBlog { get; set; }
    public string BlogURL { get; set; } = string.Empty;
    public WebBrowserDto? Browser { get; set; }
    public List<string> Certifications { get; set; } = new List<string>();
    public string Employer { get; set; } = string.Empty;
    public List<Session> Sessions { get; set; } = new List<Session>();
}
