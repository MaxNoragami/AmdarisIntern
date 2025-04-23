using BusinessLayer.Entities;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Services
{
    public class SpeakerRegistration(
        ISessionApprover sessionApprover,
        IValidator validator,
        IEvaluator feeEvaluator,
        IRepository repository) : ISpeakerRegistration
    {

        private readonly ISessionApprover _sessionApprover = sessionApprover;
        private readonly IValidator _validator = validator;
        private readonly IEvaluator _feeEvaluator = feeEvaluator;
        private readonly IRepository _repository = repository;

        public int Register(Speaker speaker)
        {
            _sessionApprover.ApproveSession(speaker.Sessions);
            _validator.Validate(speaker);
            speaker.RegistrationFee = _feeEvaluator.Evaluate(speaker.Experience);
            return _repository.SaveSpeaker(speaker);
        }
    }
}
