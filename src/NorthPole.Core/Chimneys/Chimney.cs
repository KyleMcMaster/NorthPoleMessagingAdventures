namespace NorthPole.Core.Chimneys;

public class Chimney : EntityBase<Guid>, IAggregateRoot
{
  public string ChildName { get; init; }

  public Chimney(string childName)
  {
    ChildName = childName;
  }
}

public class ChimneyByChildNameSpec : Specification<Chimney>, ISingleResultSpecification<Chimney>
{
  public ChimneyByChildNameSpec(string childName)
  {
    Query.Where(c => c.ChildName == childName);
  }
}
