namespace NorthPole.Core.Gifts;

public class AddGiftToSleighCommand : IMessage
{
  public string ChildName { get; init; }
  public string Gift { get; init; }

  public AddGiftToSleighCommand(string childName, string gift)
  {
    ChildName = childName;
    Gift = gift;
  }
}
