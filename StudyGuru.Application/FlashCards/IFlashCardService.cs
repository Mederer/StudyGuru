namespace StudyGuru.Application.FlashCards;

public interface IFlashCardService
{
    Task<IEnumerable<FlashCardResponse>> GetAllFlashCardsAsync(Guid userId);
    Task<FlashCardResponse?> GetFlashCardByIdAsync(Guid id);
    Task<FlashCardResponse?> CreateFlashCardAsync(Guid userId, CreateFlashCardRequest request);
    Task<FlashCardResponse?> UpdateFlashCardAsync(UpdateFlashCardRequest request);
    Task<bool> DeleteFlashCardAsync(Guid userId, Guid id);
}