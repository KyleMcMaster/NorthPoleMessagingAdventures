namespace NorthPole.Core.Gifts;

public class CreatePresentCommand : IMessage
{
  public string ChildName { get; init; }
  public string Present { get; init; }

  public CreatePresentCommand(string childName, string gift)
  {
    ChildName = childName;
    Present = gift;
  }
}
