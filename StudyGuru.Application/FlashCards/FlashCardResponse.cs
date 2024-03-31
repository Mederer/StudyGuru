using StudyGuru.Domain.Topics;

namespace StudyGuru.Application.FlashCards;

public record FlashCardResponse(Guid Id, string Question, string Answer, Topic Topic);