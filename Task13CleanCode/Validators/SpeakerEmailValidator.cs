using Task13CleanCode.Entities;
using Task13CleanCode.Interfaces;
using Task13CleanCode.Constants;
using Task13CleanCode.Exceptions;

namespace Task13CleanCode.Validators;

public class SpeakerEmailValidator : IValidator
{
    public void Validate(Speaker speaker)
    {
        string emailDomain = speaker.Email.Split('@').Last();
        bool isEmailDomainInvalid = SpeakerEvaluationConstants.InvalidDomains.Contains(emailDomain);

        bool isBrowserInternetExplorer = speaker.Browser.Name == WebBrowser.BrowserName.InternetExplorer;
        bool isBrowserVersionInvalid = speaker.Browser.MajorVersion < 9;

        if (isEmailDomainInvalid || (isBrowserVersionInvalid && isBrowserInternetExplorer))
            throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
    }
}
