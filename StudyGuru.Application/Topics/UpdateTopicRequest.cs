namespace StudyGuru.Application.Topics;

public record UpdateTopicRequest(Guid Id, Guid UserId, string Name);