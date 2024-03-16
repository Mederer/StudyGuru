using System.Text;
using System.Text.Json;
using Amazon;
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;
using StudyGuru.Domain.AI;

namespace StudyGuru.Infrastructure.AI;

public class BedrockRepository : IAIRepository
{
    public async Task<string> RunInferenceAsync(string prompt)
    {
        var inferenceRequest = new InferenceRequest(prompt);
        var client = new AmazonBedrockRuntimeClient(RegionEndpoint.USEast1);
        var response = await client.InvokeModelAsync(new InvokeModelRequest()
        {
            Body = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(inferenceRequest,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }))),
            ModelId = "amazon.titan-text-lite-v1",
            ContentType = "application/json",
            Accept = "application/json"
        });

        using var reader = new StreamReader(response.Body);
        return await reader.ReadToEndAsync();
    }
}