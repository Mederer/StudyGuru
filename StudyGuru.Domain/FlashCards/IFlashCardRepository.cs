namespace StudyGuru.Domain.FlashCards;

public interface IFlashCardRepository
{
    Task<FlashCard?> GetByIdAsync(Guid id);
    Task<IEnumerable<FlashCard>> GetAllAsync();
    Task<IEnumerable<FlashCard>> GetAllForUserAsync(Guid userId);
    Task<FlashCard?> CreateAsync(FlashCard flashCard);
    Task<FlashCard?> UpdateAsync(FlashCard flashCard);
    Task<bool> DeleteAsync(Guid id);
}