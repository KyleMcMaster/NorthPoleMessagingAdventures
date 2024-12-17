using NorthPole.Core.SantasSleigh;

namespace NorthPole.SantasSleigh.SantasSleigh;

public class SleighTakeoffSaga : Saga<SleighTakeoffSagaData>,
    IAmStartedByMessages<SleighContainsNewPresentEvent>,
    IHandleTimeouts<ChristmasEveTimeout>
{
  private readonly ILogger<SleighTakeoffSaga> _logger;

  public SleighTakeoffSaga(ILogger<SleighTakeoffSaga> logger)
  {
    _logger = logger;
  }

  protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SleighTakeoffSagaData> mapper)
  {
    mapper.ConfigureMapping<SleighContainsNewPresentEvent>(message => message.SleighId)
      .ToSaga(sagaData => sagaData.SleighId);
  }

  public async Task Handle(SleighContainsNewPresentEvent message, IMessageHandlerContext context)
  {
    int year = DateTime.UtcNow.Year;
    await RequestTimeout(context, DateTimeOffset.Parse($"12/24/{year}"), new ChristmasEveTimeout());
  }

  public async Task Timeout(ChristmasEveTimeout state, IMessageHandlerContext context)
  {
    // Send command for Rudolf to save the day!
    await context.Send(new LetsGoRudolfCommand(Data.SleighId));
    MarkAsComplete();
  }
}

public class SleighTakeoffSagaData : ContainSagaData
{
  public Guid SleighId { get; init; }
}

public record ChristmasEveTimeout();
