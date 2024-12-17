using NorthPole.Core.Presents;

namespace NorthPole.Core.SantasSleigh;

public class Sleigh : EntityBase<Guid>, IAggregateRoot
{
  private IEnumerable<Present> Gifts { get; init; }

  public Sleigh(IEnumerable<Present> gifts)
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

  public void DeliverGift(Present gift)
  {
    gift.Deliver();
  }
}
