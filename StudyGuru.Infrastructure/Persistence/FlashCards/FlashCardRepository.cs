using Microsoft.EntityFrameworkCore;
using StudyGuru.Domain.FlashCards;

namespace StudyGuru.Infrastructure.Persistence.FlashCards;

public class FlashCardRepository : IFlashCardRepository
{
    private readonly StudyGuruDbContext _dbContext;

    public FlashCardRepository(StudyGuruDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<FlashCard?> GetByIdAsync(Guid id)
    {
        var flashCard = await _dbContext.FlashCards.FindAsync(id);
        return flashCard;
    }

    public async Task<IEnumerable<FlashCard>> GetAllAsync()
    {
        var flashCards = await _dbContext.FlashCards.ToListAsync();
        return flashCards.AsEnumerable();
    }

    public async Task<IEnumerable<FlashCard>> GetAllForUserAsync(Guid userId)
    {
        var flashCards = await _dbContext.FlashCards.Where(x => x.UserId == userId).ToListAsync();
        return flashCards.AsEnumerable();
    }

    public async Task<FlashCard?> CreateAsync(FlashCard flashCard)
    {
        var savedFlashCard = await _dbContext.FlashCards.AddAsync(flashCard);
        await _dbContext.SaveChangesAsync();
        return savedFlashCard.Entity;
    }

    public async Task<FlashCard?> UpdateAsync(FlashCard flashCard)
    {
        var updatedFlashCard = _dbContext.FlashCards.Update(flashCard);
        await _dbContext.SaveChangesAsync();
        return updatedFlashCard.Entity;
    }

    public async Task<bool> DeleteAsync(Guid userId, Guid id)
    {
        var flashCard = await _dbContext.FlashCards.FindAsync(id);
        if (flashCard is null || flashCard.UserId != userId)
        {
            return false;
        }
        
        _dbContext.FlashCards.Remove(flashCard);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}