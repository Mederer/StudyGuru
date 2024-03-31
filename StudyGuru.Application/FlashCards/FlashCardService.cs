using StudyGuru.Domain.FlashCards;
using StudyGuru.Domain.Topics;

namespace StudyGuru.Application.FlashCards;

public class FlashCardService : IFlashCardService
{
    private readonly IFlashCardRepository _flashCardRepository;
    private readonly ITopicRepository _topicRepository;

    public FlashCardService(IFlashCardRepository flashCardRepository, ITopicRepository topicRepository)
    {
        _flashCardRepository = flashCardRepository;
        _topicRepository = topicRepository;
    }

    public async Task<IEnumerable<FlashCardResponse>> GetAllFlashCardsAsync(Guid userId)
    {
        var flashCards = await _flashCardRepository.GetAllForUserAsync(userId);
        return flashCards.Select(x => new FlashCardResponse(x.Id, x.Question, x.Answer, x.Topic));
    }

    public async Task<FlashCardResponse?> GetFlashCardByIdAsync(Guid id)
    {
        var flashCard = await _flashCardRepository.GetByIdAsync(id);
        return flashCard is not null ? new FlashCardResponse(flashCard.Id, flashCard.Question, flashCard.Answer, flashCard.Topic) : null;
    }

    public async Task<FlashCardResponse?> CreateFlashCardAsync(Guid userId, CreateFlashCardRequest request)
    {
        var topic = await _topicRepository.GetByIdAsync(userId, request.topicId);
        if (topic is null)
        {
            return null;
        }
        var newFlashCard = new FlashCard(userId, request.Question, request.Answer, topic);
        var savedFlashCard = await _flashCardRepository.CreateAsync(newFlashCard);
        return savedFlashCard is not null ? new FlashCardResponse(savedFlashCard.Id, savedFlashCard.Question, savedFlashCard.Answer, savedFlashCard.Topic) : null;
    }

    public async Task<FlashCardResponse?> UpdateFlashCardAsync(UpdateFlashCardRequest request)
    {
        var flashCardToUpdate = await _flashCardRepository.GetByIdAsync(request.Id);
        if (flashCardToUpdate is null)
        {
            return null;
        }

        if (flashCardToUpdate.Topic.Id != request.TopicId)
        {
            var topic = await _topicRepository.GetByIdAsync(flashCardToUpdate.UserId, request.TopicId);
            if (topic is null)
            {
                return null;
            }
            flashCardToUpdate.UpdateTopic(topic);
        }

        flashCardToUpdate.UpdateQuestion(request.Question);
        flashCardToUpdate.UpdateAnswer(request.Answer);

        var updatedFlashCard = await _flashCardRepository.UpdateAsync(flashCardToUpdate);
        return updatedFlashCard is not null ? new FlashCardResponse(updatedFlashCard.Id, updatedFlashCard.Question, updatedFlashCard.Answer, updatedFlashCard.Topic) : null;
    }

    public Task<bool> DeleteFlashCardAsync(Guid userId, Guid id)
    {
        return _flashCardRepository.DeleteAsync(userId, id);
    }
}