using NorthPole.Core.Gifts;

namespace NorthPole.Core.SantasSleigh;

public class Sleigh : EntityBase<Guid>, IAggregateRoot
{
  private IEnumerable<Gift> Gifts { get; init; }

  public Sleigh(IEnumerable<Gift> gifts)
  {
    Gifts = gifts;
  }

  public void Takeoff()
  {
    foreach (var gift in Gifts)
    {
      gift.MarkInFlight();
    }
  }

  public void DeliverGift(Gift gift)
  {
    gift.Deliver();
  }
}
