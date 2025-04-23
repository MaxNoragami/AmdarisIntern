using BusinessLayer.Entities;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Repositories;

public class ListRepository() : IRepository
{
    private static readonly List<Speaker> _speakers = new List<Speaker>();

    public int SaveSpeaker(Speaker speaker)
    {
        _speakers.Add(speaker);
        return _speakers.IndexOf(speaker);
    }

    public IReadOnlyCollection<Speaker> GetAllSpeakers()
        => _speakers;
}