namespace StudyGuru.Infrastructure.Persistence.FlashCards;

public class FlashCardModel
{
    public Guid Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}