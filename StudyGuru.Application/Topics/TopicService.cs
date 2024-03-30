using StudyGuru.Domain.Topics;

namespace StudyGuru.Application.Topics;

public class TopicService : ITopicService
{
    private readonly ITopicRepository _topicRepository;

    public TopicService(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<IEnumerable<TopicResponse>> GetAllTopicsAsync(Guid userId)
    {
        var topics = await _topicRepository.GetAllAsync(userId);
        return topics.Select(x => new TopicResponse(x.Id, x.Name));
    }

    public Task<TopicResponse?> GetTopicByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<TopicResponse?> CreateTopicAsync(Guid userId, CreateTopicRequest request)
    {
        var newTopic = new Topic(userId, request.Name);
        var savedTopic = await _topicRepository.CreateAsync(newTopic);
        return savedTopic is not null ? new TopicResponse(savedTopic.Id, savedTopic.Name) : null;
    }

    public Task<TopicResponse?> UpdateTopicAsync(UpdateTopicRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteTopicAsync(Guid userId, Guid id)
    {
        throw new NotImplementedException();
    }
}