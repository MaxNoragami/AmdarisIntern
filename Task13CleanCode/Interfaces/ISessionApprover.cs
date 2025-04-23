using Task13CleanCode.Entities;

namespace Task13CleanCode.Interfaces;

public interface ISessionApprover
{
    public void ApproveSession(List<Session> sessions);
}
