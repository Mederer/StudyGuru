using StudyGuru.Domain.FlashCards;

namespace StudyGuru.Infrastructure.Persistence.FlashCards;

public class InMemoryFlashCardRepository : IFlashCardRepository
{
    private List<FlashCard> _flashCards = [];

    public InMemoryFlashCardRepository()
    {
        _flashCards.Add(new FlashCard(Guid.Parse("a6088d10-29b0-4447-8feb-90ccfdc1401c"), "What is the capital of France?", "Paris"));
        _flashCards.Add(new FlashCard(Guid.Parse("a6088d10-29b0-4447-8feb-90ccfdc1401c"), "What is the capital of Germany?", "Berlin"));
    }
    public Task<FlashCard?> GetByIdAsync(Guid id)
    {
        var flashCard = _flashCards.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(flashCard);
    }

    public Task<IEnumerable<FlashCard>> GetAllAsync()
    {
        return Task.FromResult(_flashCards.AsEnumerable());
    }

    public Task<IEnumerable<FlashCard>> GetAllForUserAsync(Guid userId)
    {
        var flashCards = _flashCards.FindAll(x => x.UserId == userId);
        Console.WriteLine($"Found {flashCards.Count} flashcards for user {userId}.");
        return Task.FromResult(flashCards.AsEnumerable());
    }

    public Task<FlashCard?> CreateAsync(FlashCard flashCard)
    {
        _flashCards.Add(flashCard);
        return Task.FromResult<FlashCard?>(flashCard);
    }

    public Task<FlashCard?> UpdateAsync(FlashCard flashCard)
    {
        var index = _flashCards.FindIndex(x => x.Id == flashCard.Id);
        if (index == -1)
        {
            return Task.FromResult<FlashCard?>(null);
        }
        
        _flashCards[index] = flashCard;
        return Task.FromResult<FlashCard?>(flashCard);
    }

    public Task<bool> DeleteAsync(Guid userId, Guid id)
    {
        var flashCard = _flashCards.FirstOrDefault(x => x.Id == id && x.UserId == userId);
        if (flashCard is null)
        {
            return Task.FromResult(false);
        }
        
        _flashCards.Remove(flashCard);
        return Task.FromResult(true);
    }
}