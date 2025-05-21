using BusinessLayer.Interfaces;
using BusinessLayer.Repositories;
using BusinessLayer.Services;
using BusinessLayer.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSpeakerRegistration(this IServiceCollection services)
    {
        services.AddScoped<ISpeakerValidatorComponent, SpeakerRequiredFieldsValidator>();
        services.AddScoped<ISpeakerValidatorComponent, SpeakerEmailValidator>();
        services.AddScoped<ISpeakerValidatorComponent, SpeakerProfessionalRequirementsValidator>();
        services.AddScoped<ISpeakerValidatorComponent, SpeakerSessionValidator>();

        services.AddScoped<ISessionApprover, SessionApprover>();
        services.AddScoped<IValidator, SpeakerValidator>();
        services.AddScoped<IEvaluator, RegistrationFeeEvaluator>();
        services.AddScoped<IRepository, ListRepository>();
        services.AddScoped<ISpeakerRegistration, SpeakerRegistration>();
        return services;
    }
}
