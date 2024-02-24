using StudyGuru.Domain.FlashCards;

namespace StudyGuru.Application.FlashCards;

public class FlashCardService : IFlashCardService
{
    public Task<IEnumerable<FlashCardResponse>> GetAllFlashCardsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<FlashCardResponse?> GetFlashCardById(Guid id)
    {
        throw new NotImplementedException();
    }
}