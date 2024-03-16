namespace StudyGuru.Application.FlashCards;

public record CreateFlashCardRequest(Guid UserId, string Question, string Answer);