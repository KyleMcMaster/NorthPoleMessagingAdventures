namespace NorthPole.Core.Presents;

public class Present : EntityBase<Guid>, IAggregateRoot
{
  public string ChildName { get; init; }
  public string Type { get; init; }
  public PresentStatus Status { get; private set; }
  public Guid? ChimneyId { get; private set; }

  public Present(string childName, string type, PresentStatus status, Guid? chimneyId)
  {
    ChildName = childName;
    Type = type;
    Status = status;
  }

  public void MarkInFlight()
  {
    Status = PresentStatus.InFlight;
  }

  public void Deliver()
  {
    Status = PresentStatus.Delivered;
  }

  public void SetDestination(Guid chimneyId)
  {
    ChimneyId = chimneyId;
  }

  public void PlaceOnSleigh()
  {
    Status = PresentStatus.OnSleigh;
  }
}

public sealed class PresentStatus : SmartEnum<PresentStatus>
{
  public static readonly PresentStatus Created = new(nameof(Created), 1);
  public static readonly PresentStatus OnSleigh = new(nameof(OnSleigh), 2);
  public static readonly PresentStatus InFlight = new(nameof(InFlight), 3);
  public static readonly PresentStatus Delivered = new(nameof(Delivered), 4);

  private PresentStatus(string name, int value) : base(name, value)
  {
  }
}
