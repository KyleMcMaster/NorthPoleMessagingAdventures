namespace NorthPole.Core.NaughtyOrNice;

public class NaughtyOrNiceList
{
  private readonly Dictionary<string, bool> _children = new()
        {
            { "Bob", true },
            { "David", true },
            { "Elon", false },
            // { "Kyle", 🤷‍♂️ },
            { "Michelle", true },
            { "Nathan", false },
            { "Sarah", true },
        };

  public bool IsNice(string childName)
  {
    return _children.TryGetValue(childName, out var isNice) && isNice;
  }
}
