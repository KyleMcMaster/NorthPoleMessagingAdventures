namespace NorthPole.Core.SantasSleigh;

public class SleighLoadedWithNewGiftEvent : IMessage
{
  public Guid SleighId { get; init; }
  public Guid ChimneyId { get; init; }

  public SleighLoadedWithNewGiftEvent(Guid sleighId, Guid chimneyId)
  {
    SleighId = sleighId;
    ChimneyId = chimneyId;
  }
}
