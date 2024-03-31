using StudyGuru.Domain.Topics;

namespace StudyGuru.Domain.FlashCards;

public class FlashCard
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Question { get; private set; }
    public string Answer { get; private set; }
    
    public Topic Topic { get; private set; }

    private FlashCard()
    {
    }

    public FlashCard(Guid userId, string question, string answer, Topic topic)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Question = question;
        Answer = answer;
        Topic = topic;
    }

    public void UpdateQuestion(string question)
    {
        if (question.Length < 5)
        {
            throw new ArgumentException("Question must be at least 5 characters long.");
        }
        Question = question;
    }

    public void UpdateAnswer(string answer)
    {
        if (answer.Length < 5)
        {
            throw new ArgumentException("Answer must be at least 5 characters long.");
        }
        Answer = answer;
    }

    public void UpdateTopic(Topic topic)
    {
        Topic = topic;
    }
}