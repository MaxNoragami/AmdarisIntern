using Task13CleanCode.Entities;
using Task13CleanCode.Interfaces;

namespace Task13CleanCode.Validators;

public class SpeakerValidator(params ISpeakerValidatorComponent[] validators) : IValidator
{
    private readonly ISpeakerValidatorComponent[] _validators = validators;

    public void Validate(Speaker speaker)
    {
        foreach (var validator in _validators)
            validator.Validate(speaker);
    }
}