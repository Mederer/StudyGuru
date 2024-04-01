using StudyGuru.Domain.FlashCards;

namespace StudyGuru.Domain.Topics;

public class Topic
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    
    public string Colour { get; private set; }
    
    // public ICollection<FlashCard> FlashCards { get; private set; }

    public Topic(Guid userId, string name, string colour)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
        Colour = colour;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
    
    public void UpdateColour(string colour)
    {
        Colour = colour;
    }
}