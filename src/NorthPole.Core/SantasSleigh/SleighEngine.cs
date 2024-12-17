using NorthPole.Core.Presents;

namespace NorthPole.Core.SantasSleigh;

public interface ISleighEngine
{
  void Takeoff(Sleigh sleigh);
}

public class SleighEngine : ISleighEngine
{
  private const string _reindeerMotivationalSpeech = """
    Santa's sleigh is taking off!
    On Rudolph, on Dasher, on Dancer, on Prancer, on Vixen, on Comet, on Cupid, on Donner and on Blitzen.
    Rudolph's nose is glowing!
    The reindeer are ready to fly!
    Santa's sleigh has taken off!
    """;
  private readonly ILogger _logger;
  private List<Present> _presents;
  public IReadOnlyCollection<Present> Presents => _presents.AsReadOnly();

  public SleighEngine(ILogger<SleighEngine> logger, List<Present> presents)
  {
    _logger = logger;
    _presents = presents;
  }

  public void Takeoff(Sleigh sleigh)
  {
    sleigh.Takeoff();
    _logger.LogInformation(_reindeerMotivationalSpeech);
  }
}


