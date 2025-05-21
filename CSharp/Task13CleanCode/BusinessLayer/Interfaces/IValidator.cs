using BusinessLayer.Entities;

namespace BusinessLayer.Interfaces;

public interface IValidator
{
    public void Validate(Speaker speaker);
}
