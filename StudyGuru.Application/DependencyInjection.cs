using Microsoft.Extensions.DependencyInjection;
using StudyGuru.Application.FlashCards;
using StudyGuru.Application.Topics;

namespace StudyGuru.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IFlashCardService, FlashCardService>();
        services.AddScoped<ITopicService, TopicService>();
    }
}