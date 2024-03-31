using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudyGuru.Domain.FlashCards;
using StudyGuru.Domain.Topics;
using StudyGuru.Infrastructure.Persistence;
using StudyGuru.Infrastructure.Persistence.FlashCards;
using StudyGuru.Infrastructure.Persistence.Topics;

namespace StudyGuru.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IFlashCardRepository, FlashCardRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();

        services.AddDbContext<StudyGuruDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}