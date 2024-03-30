using Microsoft.EntityFrameworkCore;
using StudyGuru.Domain.FlashCards;
using StudyGuru.Domain.Topics;

namespace StudyGuru.Infrastructure.Persistence;

public class StudyGuruDbContext : DbContext
{
    public DbSet<FlashCard> FlashCards { get; set; } = null!;
    public DbSet<Topic> Topics { get; set; } = null!;
    
    public StudyGuruDbContext(DbContextOptions<StudyGuruDbContext> options) : base(options)
    {
    }
}