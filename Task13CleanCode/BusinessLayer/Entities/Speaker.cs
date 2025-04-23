namespace BusinessLayer.Entities;

public class Speaker
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int? Experience { get; set; }
    public bool HasBlog { get; set; }
    public string BlogURL { get; set; } = string.Empty;
    public WebBrowser? Browser { get; set; }
    public List<string> Certifications { get; set; } = new List<string>();
    public string Employer { get; set; } = string.Empty;
    public int RegistrationFee { get; set; }
    public List<Session> Sessions { get; set; } = new List<Session>();
}
