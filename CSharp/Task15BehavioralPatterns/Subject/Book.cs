namespace Task15BehavioralPatterns.Subject;

public record Book(string Title, string Author, decimal Price)
{
    public override string ToString()
        => $"\"{Title}\" by {Author}, ${Price:F2}";
}
