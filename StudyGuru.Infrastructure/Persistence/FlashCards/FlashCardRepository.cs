using StudyGuru.Domain.FlashCards;

namespace StudyGuru.Infrastructure.Persistence.FlashCards;

public class FlashCardRepository : IFlashCardRepository
{
    public Task<FlashCard?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(new FlashCard("What is the capital of France?", "Paris"));
    }

    public Task<IEnumerable<FlashCard>> GetAllAsync()
    {
        var results = new List<FlashCard>()
        {
            new FlashCard("What is the capital of Germany?", "Berlin"),
            new FlashCard("What is the capital of Australia?", "Canberra")
        };

        return Task.FromResult(results.AsEnumerable());
    }
}