namespace StudyGuru.Application.AI;

public interface IAIService
{
    Task<string> RunInferenceAsync(string prompt);
}