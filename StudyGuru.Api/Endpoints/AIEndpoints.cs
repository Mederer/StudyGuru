using Microsoft.AspNetCore.Mvc;
using StudyGuru.Application.AI;

namespace StudyGuru.Api.Endpoints;

public static class AIEndpoints
{
    public static void MapAIEndpoints(this WebApplication app)
    {
        app.MapPost("/ai", async ([FromServices] IAIService service, [FromBody] RunInferenceRequest request) =>
        {
            var response = await service.RunInferenceAsync(request.Prompt);
            return Results.Ok(response);
        });
    }
}