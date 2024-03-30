using StudyGuru.Domain.FlashCards;

namespace StudyGuru.Application.FlashCards;

public class FlashCardService : IFlashCardService
{
    private readonly IFlashCardRepository _flashCardRepository;

    public FlashCardService(IFlashCardRepository flashCardRepository)
    {
        _flashCardRepository = flashCardRepository;
    }

    public async Task<IEnumerable<FlashCardResponse>> GetAllFlashCardsAsync(Guid userId)
    {
        var flashCards = await _flashCardRepository.GetAllForUserAsync(userId);
        return flashCards.Select(x => new FlashCardResponse(x.Id, x.Question, x.Answer));
    }

    public async Task<FlashCardResponse?> GetFlashCardByIdAsync(Guid id)
    {
        var flashCard = await _flashCardRepository.GetByIdAsync(id);
        return flashCard is not null ? new FlashCardResponse(flashCard.Id, flashCard.Question, flashCard.Answer) : null;
    }

    public async Task<FlashCardResponse?> CreateFlashCardAsync(Guid userId, CreateFlashCardRequest request)
    {
        var newFlashCard = new FlashCard(userId, request.Question, request.Answer);
        var savedFlashCard = await _flashCardRepository.CreateAsync(newFlashCard);
        return savedFlashCard is not null ? new FlashCardResponse(savedFlashCard.Id, savedFlashCard.Question, savedFlashCard.Answer) : null;
    }

    public async Task<FlashCardResponse?> UpdateFlashCardAsync(UpdateFlashCardRequest request)
    {
        var flashCardToUpdate = await _flashCardRepository.GetByIdAsync(request.Id);
        if (flashCardToUpdate is null)
        {
            return null;
        }
        
        flashCardToUpdate.UpdateQuestion(request.Question);
        flashCardToUpdate.UpdateAnswer(request.Answer);
        
        var updatedFlashCard = await _flashCardRepository.UpdateAsync(flashCardToUpdate);
        return updatedFlashCard is not null ? new FlashCardResponse(updatedFlashCard.Id, updatedFlashCard.Question, updatedFlashCard.Answer) : null;
    }

    public Task<bool> DeleteFlashCardAsync(Guid userId, Guid id)
    {
        return _flashCardRepository.DeleteAsync(userId, id);
    }
}