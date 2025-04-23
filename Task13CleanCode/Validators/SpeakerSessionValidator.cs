using Task13CleanCode.Entities;
using Task13CleanCode.Interfaces;
using Task13CleanCode.Exceptions;

namespace Task13CleanCode.Validators;

public class SpeakerSessionValidator : ISpeakerValidatorComponent
{
    public void Validate(Speaker speaker)
    {
        if (speaker.Sessions.Any(session => !session.Approved))
            throw new NoSessionsApprovedException("No sessions approved.");
    }
}
