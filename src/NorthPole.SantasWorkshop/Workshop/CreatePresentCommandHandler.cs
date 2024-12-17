using Ardalis.SharedKernel;
using NorthPole.Core.Elves;
using NorthPole.Core.Gifts;
using NorthPole.Core.Presents;

namespace NorthPole.SantasWorkshop.Workshop;

public class CreatePresentCommandHandler : IHandleMessages<CreatePresentCommand>
{
  private readonly ILogger<CreatePresentCommandHandler> _logger;
  private readonly IElfAssigner _elfAssigner;
  private IRepository<Present> _repository;

  public CreatePresentCommandHandler(ILogger<CreatePresentCommandHandler> logger, IElfAssigner elfAssigner, IRepository<Present> repository)
  {
    _logger = logger;
    _elfAssigner = elfAssigner;
    _repository = repository;
  }

  public async Task Handle(CreatePresentCommand message, IMessageHandlerContext context)
  {
    _logger.LogInformation("Workshop received present request for {ChildName} of {Present}", message.ChildName, message.Present);
    var elf = await _elfAssigner.GetNextAvailable();
    var present = elf.CreatePresent(message.ChildName, message.Present);
    await _repository.AddAsync(present, context.CancellationToken);
    _logger.LogInformation("Elf {ElfId} created present for {ChildName} of {Present}, sending to Santa's sleigh!", elf.Id, message.ChildName, message.Present);
    await context.Send(new AddPresentToSleighCommand(present.Id));
  }
}
