namespace StudyGuru.Domain.FlashCards;

public class FlashCard
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Question { get; private set; }
    public string Answer { get; private set; }
    
    public FlashCard(Guid userId, string question, string answer)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Question = question;
        Answer = answer;
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
}