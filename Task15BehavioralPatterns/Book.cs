namespace Task15BehavioralPatterns;

public record Book(string Title, string Author, decimal Price)
{
    public override string ToString()
        => $"\"{Title}\" by {Author}, ${Price:F2}";
}
