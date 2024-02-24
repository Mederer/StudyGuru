using StudyGuru.Domain.FlashCards;

namespace StudyGuru.Application.FlashCards;

public class FlashCardService : IFlashCardService
{
    private readonly IFlashCardRepository _flashCardRepository;

    public FlashCardService(IFlashCardRepository flashCardRepository)
    {
        _flashCardRepository = flashCardRepository;
    }

    public async Task<IEnumerable<FlashCardResponse>> GetAllFlashCardsAsync()
    {
        var flashCards = await _flashCardRepository.GetAllAsync();
        return flashCards.Select(x => new FlashCardResponse(x.Id, x.Question, x.Answer));
    }

    public async Task<FlashCardResponse?> GetFlashCardByIdAsync(Guid id)
    {
        var flashCard = await _flashCardRepository.GetByIdAsync(id);
        return flashCard is not null ? new FlashCardResponse(flashCard.Id, flashCard.Question, flashCard.Answer) : null;
    }

    public async Task<FlashCardResponse?> CreateFlashCardAsync(CreateFlashCardRequest request)
    {
        var newFlashCard = new FlashCard(request.Question, request.Answer);
        var savedFlashCard = await _flashCardRepository.CreateAsync(newFlashCard);
        return savedFlashCard is not null ? new FlashCardResponse(savedFlashCard.Id, savedFlashCard.Question, savedFlashCard.Answer) : null;
    }
}