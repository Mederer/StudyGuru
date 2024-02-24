using StudyGuru.Application.FlashCards;

namespace StudyGuru.Api.Endpoints;

public static class FlashCardEnpoints
{
    public static void MapFlashCardEndpoints(this WebApplication app)
    {
        app.MapGet("/flashcards", async (IFlashCardService service) =>
        {
            var flashCards = await service.GetAllFlashCardsAsync();
            return Results.Ok(flashCards);
        });
        
        app.MapGet("/flashcards/{id}", async (Guid id, IFlashCardService service) =>
        {
            var flashCard = await service.GetFlashCardByIdAsync(id);
            return flashCard is not null ? Results.Ok(flashCard) : Results.NotFound();
        });

        app.MapPost("/flashcards", async (CreateFlashCardRequest request, IFlashCardService service) =>
        {
            var newFlashCard = await service.CreateFlashCardAsync(request);
            return newFlashCard is not null
                ? Results.Created($"/flashcards/{newFlashCard.Id}", newFlashCard)
                : Results.BadRequest();
        });
    }
}