using Microsoft.Extensions.DependencyInjection;
using StudyGuru.Application.AI;
using StudyGuru.Application.FlashCards;

namespace StudyGuru.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IFlashCardService, FlashCardService>();
        services.AddScoped<IAIService, AIService>();
    }
}