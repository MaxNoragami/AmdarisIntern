using Task13CleanCode.Entities;
using Task13CleanCode.Interfaces;

namespace Task13CleanCode.Validators;

public class SpeakerRequiredFieldsValidator : ISpeakerValidatorComponent
{
    public void Validate(Speaker speaker)
    {
        if (string.IsNullOrWhiteSpace(speaker.FirstName))
            throw new ArgumentNullException(nameof(speaker), "FirstName is required.");

        if (string.IsNullOrWhiteSpace(speaker.LastName))
            throw new ArgumentNullException(nameof(speaker), "LastName is required.");

        if (string.IsNullOrWhiteSpace(speaker.Email))
            throw new ArgumentNullException(nameof(speaker), "Email is required.");
    }
}
