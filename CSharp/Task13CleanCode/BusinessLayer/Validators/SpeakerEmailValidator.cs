using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using BusinessLayer.Constants;
using BusinessLayer.Exceptions;

namespace BusinessLayer.Validators;

public class SpeakerEmailValidator : ISpeakerValidatorComponent
{
    public void Validate(Speaker speaker)
    {
        string emailDomain = speaker.Email.Split('@').Last();
        bool isEmailDomainInvalid = SpeakerEvaluationConstants.InvalidDomains.Contains(emailDomain);

        bool isBrowserInternetExplorer = speaker.Browser?.Name == WebBrowser.BrowserName.InternetExplorer;
        bool isBrowserVersionInvalid = speaker.Browser?.MajorVersion < 9;

        if (isEmailDomainInvalid || (isBrowserVersionInvalid && isBrowserInternetExplorer))
            throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
    }
}
