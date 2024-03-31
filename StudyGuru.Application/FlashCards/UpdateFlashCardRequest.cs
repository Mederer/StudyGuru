namespace StudyGuru.Application.FlashCards;

public record UpdateFlashCardRequest(Guid Id, string Question, string Answer, Guid TopicId);