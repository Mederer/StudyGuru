namespace StudyGuru.Domain.Topics;

public interface ITopicRepository
{
    Task<Topic?> CreateAsync(Topic topic);
    Task<IEnumerable<Topic>> GetAllAsync(Guid userId);

    Task<Topic?> GetByIdAsync(Guid userId, Guid id);
}