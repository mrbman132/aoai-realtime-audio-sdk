public class TokenCostCalculator
{
    private long totalInputTokens = 0;
    private long totalOutputTokens = 0;

    // Pricing based on the provided rates
    private const double INPUT_TEXT_COST_PER_M = 2.50;
    private const double OUTPUT_TEXT_COST_PER_M = 10.00;
    private const double INPUT_AUDIO_COST_PER_M = 100.00;
    private const double OUTPUT_AUDIO_COST_PER_M = 200.00;

    // Assuming all tokens are audio for this example.
    // Modify these flags if you have a mix of text and audio tokens.
    private bool isAudioSession = true;

    public void AddInputTokens(int count)
    {
        totalInputTokens += count;
    }

    public void AddOutputTokens(int count)
    {
        totalOutputTokens += count;
    }

    public void CalculateAndDisplayCost()
    {
        double inputCost = 0;
        double outputCost = 0;

        if (isAudioSession)
        {
            inputCost = (totalInputTokens / 1_000_000.0) * INPUT_AUDIO_COST_PER_M;
            outputCost = (totalOutputTokens / 1_000_000.0) * OUTPUT_AUDIO_COST_PER_M;
        }
        else
        {
            inputCost = (totalInputTokens / 1_000_000.0) * INPUT_TEXT_COST_PER_M;
            outputCost = (totalOutputTokens / 1_000_000.0) * OUTPUT_TEXT_COST_PER_M;
        }

        double totalCost = inputCost + outputCost;

        Console.WriteLine("---------- Token Usage ----------");
        Console.WriteLine($"Total Input Tokens: {totalInputTokens}");
        Console.WriteLine($"Total Output Tokens: {totalOutputTokens}");
        Console.WriteLine("---------------------------------");
        Console.WriteLine($"Input Cost: ${inputCost:F4}");
        Console.WriteLine($"Output Cost: ${outputCost:F4}");
        Console.WriteLine($"Total Cost: ${totalCost:F4}");
        Console.WriteLine("---------------------------------");
    }
}