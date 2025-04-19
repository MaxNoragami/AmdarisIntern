namespace Task10DisposalGC;

public static class EnvReader
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"No file with path {filePath} exits.");

        foreach(var line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(filePath) || filePath.StartsWith('#'))
                continue;

            var pair = line.Split('=', 2);
            if (pair.Length != 2)
                continue;

            var key = pair[0].Trim();
            var value = pair[1].Trim();

            Environment.SetEnvironmentVariable(key, value);
        }
    }
}
