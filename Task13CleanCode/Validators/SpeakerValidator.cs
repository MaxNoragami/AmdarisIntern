using Task13CleanCode.Entities;
using Task13CleanCode.Interfaces;

namespace Task13CleanCode.Validators;

public class SpeakerValidator(params IValidator[] validators) : IValidator
{
    public void Validate(Speaker speaker)
    {
        foreach (var validator in validators)
            validator.Validate(speaker);
    }
}