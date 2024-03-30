using Microsoft.EntityFrameworkCore;
using StudyGuru.Domain.Topics;

namespace StudyGuru.Infrastructure.Persistence.Topics;

public class TopicRepository : ITopicRepository
{
    private readonly StudyGuruDbContext _context;

    public TopicRepository(StudyGuruDbContext context)
    {
        _context = context;
    }

    public async Task<Topic?> CreateAsync(Topic topic)
    {
        var exists = await _context.Topics.AnyAsync(x => x.Name == topic.Name && x.UserId == topic.UserId);
        if (exists)
        {
            return null;
        }
        _context.Topics.Add(topic);
        return await _context.SaveChangesAsync().ContinueWith(_ => topic);
    }

    public async Task<IEnumerable<Topic>> GetAllAsync(Guid userId)
    {
        var topics = await _context.Topics.Where(x => x.UserId == userId).ToListAsync();
        return topics.AsEnumerable();
    }
}