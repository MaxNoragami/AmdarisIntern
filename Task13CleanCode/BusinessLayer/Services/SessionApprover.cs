using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using BusinessLayer.Constants;

namespace BusinessLayer.Services;

public class SessionApprover : ISessionApprover
{
    public void ApproveSession(List<Session> sessions)
    {
        if(sessions.Count == 0)
            throw new ArgumentException("Can't register speaker with no sessions to present.");

        foreach(var session in sessions)
        {
            session.Approved = !SpeakerEvaluationConstants.OutdatedTech
                                .Any(tech => session.Title.Contains(tech) || 
                                             session.Description.Contains(tech));
        }
    }
}
