using Microsoft.Extensions.DependencyInjection;
using StudyGuru.Domain.AI;
using StudyGuru.Domain.FlashCards;
using StudyGuru.Infrastructure.AI;
using StudyGuru.Infrastructure.Persistence.FlashCards;

namespace StudyGuru.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFlashCardRepository, InMemoryFlashCardRepository>();
        services.AddScoped<IAIRepository, BedrockRepository>();
    }
}