namespace NorthPole.Core.Letters;

  public class LetterToSanta : IMessage
  {
      public string ChildName { get; init; }
      public string Gift { get; init; }

      public LetterToSanta(string childName, string gift)
      {
          ChildName = childName;
          Gift = gift;
      }
  }
