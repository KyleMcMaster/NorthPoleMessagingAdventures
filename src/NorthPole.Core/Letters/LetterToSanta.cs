namespace NorthPole.Core.Letters;

  public class LetterToSanta : IMessage
  {
      public string ChildName { get; init; }
      public string Present { get; init; }

      public LetterToSanta(string childName, string present)
      {
          ChildName = childName;
          Present = present;
      }
  }
