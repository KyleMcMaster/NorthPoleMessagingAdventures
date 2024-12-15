namespace NorthPole.Core.Gifts;

public class Gift : EntityBase<Guid>
{
  public string ChildName { get; init; }
  public Guid GiftId { get; init; }
  public string Type { get; init; }
  public bool InFlight { get; private set; }
  public bool IsDelivered { get; private set; }

  public Gift(string childName, Guid giftId, string type, bool inFlight, bool isDelivered)
  {
    ChildName = childName;
    GiftId = giftId;
    Type = type;
  }

  public void MarkInFlight()
  {
    InFlight = true;
  }

  public void Deliver()
  {
    InFlight = false;
    IsDelivered = true;
  }
}
