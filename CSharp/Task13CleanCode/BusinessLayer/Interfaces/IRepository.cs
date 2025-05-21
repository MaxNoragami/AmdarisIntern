using BusinessLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IRepository
{
    int SaveSpeaker(Speaker speaker);
    IReadOnlyCollection<Speaker> GetAllSpeakers();
}
