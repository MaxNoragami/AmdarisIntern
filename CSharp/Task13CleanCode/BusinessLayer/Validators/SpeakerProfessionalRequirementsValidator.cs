using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using BusinessLayer.Constants;
using BusinessLayer.Exceptions;

namespace BusinessLayer.Validators;

public class SpeakerProfessionalRequirementsValidator : ISpeakerValidatorComponent
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
