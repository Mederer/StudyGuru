using StudyGuru.Domain.FlashCards;

namespace StudyGuru.Infrastructure.Persistence.FlashCards;

public class InMemoryFlashCardRepository : IFlashCardRepository
{
    private List<FlashCard> _flashCards = new();

    public InMemoryFlashCardRepository()
    {
        _flashCards.Add(new FlashCard("What is the capital of France?", "Paris"));
        _flashCards.Add(new FlashCard("What is the capital of Germany?", "Berlin"));
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

    public Task<FlashCard?> CreateAsync(FlashCard flashCard)
    {
        _flashCards.Add(flashCard);
        return Task.FromResult<FlashCard?>(flashCard);
    }
}