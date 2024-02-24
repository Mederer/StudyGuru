namespace StudyGuru.Application.FlashCards;

public interface IFlashCardService
{
    Task<IEnumerable<FlashCardResponse>> GetAllFlashCardsAsync();
    Task<FlashCardResponse?> GetFlashCardById(Guid id);
}