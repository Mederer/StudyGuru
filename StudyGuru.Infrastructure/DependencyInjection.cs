using Microsoft.Extensions.DependencyInjection;
using StudyGuru.Domain.FlashCards;
using StudyGuru.Infrastructure.Persistence.FlashCards;

namespace StudyGuru.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFlashCardRepository, InMemoryFlashCardRepository>();
    }
}