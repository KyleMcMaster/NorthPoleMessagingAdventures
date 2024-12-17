namespace NorthPole.Core.Elves;

public interface IElfAssigner
{
    Task<Elf> GetNextAvailable();
}

public class ElfAssigner : IElfAssigner
{
    private readonly IRepository<Elf> _repository;

    public ElfAssigner(IRepository<Elf> repository)
    {
        _repository = repository;
    }

  public async Task<Elf> GetNextAvailable()
  {
    var elf = await _repository.SingleOrDefaultAsync(new ElfByLeastWorkloadSpec());
    return elf!;
  }
}

public class ElfByLeastWorkloadSpec : Specification<Elf>, ISingleResultSpecification<Elf>
{
  public ElfByLeastWorkloadSpec()
  {
    Query.OrderBy(elf => elf.CurrentWorkload);
  }
}
