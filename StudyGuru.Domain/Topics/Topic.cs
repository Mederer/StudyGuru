namespace StudyGuru.Domain.Topics;

public class Topic
{
    public Guid Id { get; private set; }

    public Guid UserId { get; private set; }
    public string Name { get; private set; }

    public Topic(Guid userId, string name)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}