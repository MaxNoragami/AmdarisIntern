using Task13CleanCode.Entities;
using Task13CleanCode.Interfaces;
using Task13CleanCode.Constants;

namespace Task13CleanCode.Services;

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
