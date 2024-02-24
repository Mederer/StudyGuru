namespace StudyGuru.Domain.FlashCards;

public interface IFlashCardRepository
{
    Task<FlashCard?> GetByIdAsync(Guid id);
    Task<IEnumerable<FlashCard>> GetAllAsync();
}