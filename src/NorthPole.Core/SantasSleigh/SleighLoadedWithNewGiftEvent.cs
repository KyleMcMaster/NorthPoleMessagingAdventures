namespace NorthPole.Core.SantasSleigh;

public class SleighContainsNewPresentEvent : IMessage
{
  public Guid SleighId { get; init; }

  public SleighContainsNewPresentEvent(Guid sleighId)
  {
    SleighId = sleighId;
  }
}
