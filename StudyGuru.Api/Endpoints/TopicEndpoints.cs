using StudyGuru.Api.Extensions;
using StudyGuru.Application.Topics;

namespace StudyGuru.Api.Endpoints;

public static class TopicEndpoints
{
    public static void MapTopicEndpoints(this WebApplication app)
    {
        app.MapPost("/topics", async (CreateTopicRequest request, ITopicService service, HttpContext context) =>
        {
            var userId = context.User.GetUserId();
            if (!userId.HasValue)
            {
                return Results.Unauthorized();
            }

            var newTopic = await service.CreateTopicAsync(userId.Value, request);
            return newTopic is not null
                ? Results.Created($"/topics/{newTopic.Id}", newTopic)
                : Results.BadRequest();
        });
        
        app.MapGet("/topics", async (ITopicService service, HttpContext context) =>
        {
            var userId = context.User.GetUserId();
            if (!userId.HasValue)
            {
                return Results.Unauthorized();
            }
            
            var topics = await service.GetAllTopicsAsync(userId.Value);
            return Results.Ok(topics);
        }).RequireAuthorization();
    }
}