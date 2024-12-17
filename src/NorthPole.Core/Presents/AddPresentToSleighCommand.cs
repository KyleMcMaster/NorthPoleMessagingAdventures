namespace NorthPole.Core.Presents;

public class AddPresentToSleighCommand : IMessage
{
  public Guid PresentId { get; init; }

  public AddPresentToSleighCommand(Guid presentId)
  {
    PresentId = presentId;
  }
}
