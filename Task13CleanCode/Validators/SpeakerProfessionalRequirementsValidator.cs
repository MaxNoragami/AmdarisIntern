using Task13CleanCode.Entities;
using Task13CleanCode.Interfaces;
using Task13CleanCode.Constants;
using Task13CleanCode.Exceptions;

namespace Task13CleanCode.Validators;

public class SpeakerProfessionalRequirementsValidator : IValidator
{
    public void Validate(Speaker speaker)
    {
        bool speakerMeetsRequirements =
                    speaker.Experience > SpeakerEvaluationConstants.MininumYearsOfExperience ||
                    speaker.HasBlog ||
                    speaker.Certifications.Count > SpeakerEvaluationConstants.MinimumCertifications ||
                    SpeakerEvaluationConstants.ValuableEmployers.Contains(speaker.Employer);

        if (!speakerMeetsRequirements)
            throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
    }
}
