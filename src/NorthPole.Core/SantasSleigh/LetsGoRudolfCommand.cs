namespace NorthPole.Core.SantasSleigh;

public class LetsGoRudolfCommand : IMessage
{
  public Guid SleighId { get; init; }
  
  public LetsGoRudolfCommand(Guid sleighId)
  {
    SleighId = sleighId;
  }
}
