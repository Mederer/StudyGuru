using StudyGuru.Domain.AI;

namespace StudyGuru.Application.AI;

public class AIService : IAIService
{
    private readonly IAIRepository _aiRepository;

    public AIService(IAIRepository aiRepository)
    {
        _aiRepository = aiRepository;
    }

    public Task<string> RunInferenceAsync(string prompt)
    {
        return _aiRepository.RunInferenceAsync(prompt);
    }
}