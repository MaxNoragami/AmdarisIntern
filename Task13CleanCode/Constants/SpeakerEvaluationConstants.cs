namespace Task13CleanCode.Constants;

public static class SpeakerEvaluationConstants
{
    public static IReadOnlyCollection<string> OutdatedTech => new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };
    public static IReadOnlyCollection<string> ValuableEmployers => new List<string>() { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
    public static IReadOnlyCollection<string> InvalidDomains => new List<string>() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
}
