using NorthPole.Core.Presents;

namespace NorthPole.Core.SantasSleigh;

public class Sleigh : EntityBase<Guid>, IAggregateRoot
{
  private List<Present> _presents { get; init; }
  public IReadOnlyCollection<Present> Presents => _presents.AsReadOnly();  

  public Sleigh(List<Present> presents)
  {
    _presents = presents;
  }

  public void Takeoff()
  {
    foreach (var present in _presents)
    {
      present.MarkInFlight();
    }
  }

  public void DeliverPresent(Present present)
  {
    present.Deliver();
  }

  public void AddPresent(Present present)
  {
    _presents.Add(present);
    present.PlaceOnSleigh();
  }
}

public class SantasSleighSpecification : Specification<Sleigh>, ISingleResultSpecification<Sleigh>
{
  public SantasSleighSpecification()
  {
    Query.Include(s => s.Presents);
  }
}
