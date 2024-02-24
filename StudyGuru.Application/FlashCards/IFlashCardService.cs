namespace StudyGuru.Application.FlashCards;

public interface IFlashCardService
{
    Task<IEnumerable<FlashCardResponse>> GetAllFlashCardsAsync();
    Task<FlashCardResponse?> GetFlashCardByIdAsync(Guid id);
    Task<FlashCardResponse?> CreateFlashCardAsync(CreateFlashCardRequest request);
}