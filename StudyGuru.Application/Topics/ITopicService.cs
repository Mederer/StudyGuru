namespace StudyGuru.Application.Topics;

public interface ITopicService
{
    Task<IEnumerable<TopicResponse>> GetAllTopicsAsync(Guid userId);
    Task<TopicResponse?> GetTopicByIdAsync(Guid userId, Guid id);
    Task<TopicResponse?> CreateTopicAsync(Guid userId, CreateTopicRequest request);
    Task<TopicResponse?> UpdateTopicAsync(UpdateTopicRequest request);
    Task<bool> DeleteTopicAsync(Guid userId, Guid id);
}