using Task13CleanCode.Entities;
using Task13CleanCode.Interfaces;

namespace Task13CleanCode.Repositories;

public class ListRepository<T>() : IRepository
{
    private readonly List<Speaker> _speakers = new List<Speaker>();

    public int SaveSpeaker(Speaker speaker)
    {
        _speakers.Add(speaker);
        return _speakers.IndexOf(speaker);
    }
}