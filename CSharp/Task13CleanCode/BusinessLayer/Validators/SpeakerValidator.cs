using BusinessLayer.Entities;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Validators;

public class SpeakerValidator(params IEnumerable<ISpeakerValidatorComponent> validators) : IValidator
{
    private readonly IEnumerable<ISpeakerValidatorComponent> _validators = validators;

    public void Validate(Speaker speaker)
    {
        foreach (var validator in _validators)
            validator.Validate(speaker);
    }
}