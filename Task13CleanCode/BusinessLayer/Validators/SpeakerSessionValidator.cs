using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using BusinessLayer.Exceptions;

namespace BusinessLayer.Validators;

public class SpeakerSessionValidator : ISpeakerValidatorComponent
{
    public void Validate(Speaker speaker)
    {
        if (speaker.Sessions.Any(session => !session.Approved))
            throw new NoSessionsApprovedException("No sessions approved.");
    }
}
