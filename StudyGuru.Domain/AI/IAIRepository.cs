namespace StudyGuru.Domain.AI;

public interface IAIRepository
{
    Task<string> RunInferenceAsync(string prompt);
}