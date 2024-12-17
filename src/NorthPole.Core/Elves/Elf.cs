using NorthPole.Core.Presents;

namespace NorthPole.Core.Elves;

public class Elf : EntityBase<Guid>, IAggregateRoot
{
    public string Name { get; init; }
    public int CurrentWorkload { get; private set; }

    public Elf(string name, int currentWorkload)
    {
        Name = name;
        CurrentWorkload = currentWorkload;
    }

    public Present CreatePresent(string childName, string present)
    {
        CurrentWorkload++;
        return new Present(childName, present, PresentStatus.Created, default);
    }
}
