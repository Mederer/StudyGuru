namespace StudyGuru.Api.Endpoints;

public static class FlashCardEnpoints
{
    public static void MapFlashCardEndpoints(this WebApplication app)
    {
        app.MapGet("/flashcards", async () => "Hello World!");
    }
}