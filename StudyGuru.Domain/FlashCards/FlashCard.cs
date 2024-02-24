namespace StudyGuru.Domain.FlashCards;

public class FlashCard
{
    public Guid Id { get; private set; }
    public string Question { get; private set; }
    public string Answer { get; private set; }
    
    public FlashCard(string question, string answer)
    {
        Id = Guid.NewGuid();
        Question = question;
        Answer = answer;
    }
    
    public void UpdateQuestion(string question)
    {
        Question = question;
    }
    
    public void UpdateAnswer(string answer)
    {
        Answer = answer;
    }
}