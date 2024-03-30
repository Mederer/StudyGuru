using StudyGuru.Api.Extensions;
using StudyGuru.Application.FlashCards;

namespace StudyGuru.Api.Endpoints;

public static class FlashCardEndpoints
{
    public static void MapFlashCardEndpoints(this WebApplication app)
    {
        app.MapGet("/flashcards", async (IFlashCardService service, HttpContext context) =>
        {
            var userId = context.User.GetUserId();
            if (!userId.HasValue)
            {
                return Results.Unauthorized();
            }
            
            var flashCards = await service.GetAllFlashCardsAsync(userId.Value);
            return Results.Ok(flashCards);

        }).RequireAuthorization();
        
        app.MapGet("/flashcards/{id}", async (Guid id, IFlashCardService service) =>
        {
            var flashCard = await service.GetFlashCardByIdAsync(id);
            return flashCard is not null ? Results.Ok(flashCard) : Results.NotFound();
        });

        app.MapPost("/flashcards", async (CreateFlashCardRequest request, IFlashCardService service, HttpContext context) =>
        {
            var userId = context.User.GetUserId();
            if (!userId.HasValue)
            {
                return Results.Unauthorized();
            }
            
            var newFlashCard = await service.CreateFlashCardAsync(userId.Value, request);
            return newFlashCard is not null
                ? Results.Created($"/flashcards/{newFlashCard.Id}", newFlashCard)
                : Results.BadRequest();
        }).RequireAuthorization();

        app.MapPut("/flashcards", async (UpdateFlashCardRequest request, IFlashCardService service, HttpContext context) =>
        {
            var userId = context.User.GetUserId();
            if (!userId.HasValue)
            {
                return Results.Unauthorized();
            }
            
            var updatedFlashCard = await service.UpdateFlashCardAsync(request);
            return updatedFlashCard is not null
                ? Results.Ok(updatedFlashCard)
                : Results.NotFound();
        });
        
        app.MapDelete("/flashcards/{id}", async (Guid id, IFlashCardService service, HttpContext context) =>
        {
            var userId = context.User.GetUserId();
            if (!userId.HasValue)
            {
                return Results.Unauthorized();
            }
            var deleted = await service.DeleteFlashCardAsync(userId.Value, id);
            return deleted ? Results.NoContent() : Results.NotFound();
        }).RequireAuthorization();
    }
}