namespace NorthPole.Core.NaughtyOrNice;

public class NaughtyOrNiceList
{
  private readonly Dictionary<string, bool> _list = new()
        {
            { "Bob", true },
            { "David", true },
            { "Elon", false },
            // { "Kyle", 🤷‍♂️ },
            { "Nathan", false },
            { "Sarah", true },
            { "Sean", true }
        };

  public bool IsNice(string childName)
  {
    return _list.TryGetValue(childName, out var isNice) && isNice;
  }
}
