using BusinessLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface ISpeakerValidatorComponent
{
    public void Validate(Speaker speaker);
}
