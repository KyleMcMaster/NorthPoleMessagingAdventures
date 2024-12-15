using NorthPole.Core.SantasSleigh;

namespace NorthPole.SantasSleigh.SantasSleigh;

public class SleighTakeoffSaga : Saga<SleighTakeoffSagaData>,
    IAmStartedByMessages<SleighLoadedWithNewGiftEvent>,
    IHandleTimeouts<ChristmasEveTimeout>
{
  private readonly ILogger<SleighTakeoffSaga> _logger;

  public SleighTakeoffSaga(ILogger<SleighTakeoffSaga> logger)
  {
    _logger = logger;
  }

  protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SleighTakeoffSagaData> mapper)
  {
    mapper.ConfigureMapping<SleighLoadedWithNewGiftEvent>(message => message.SleighId)
      .ToSaga(sagaData => sagaData.SleighId);
  }

  public async Task Handle(SleighLoadedWithNewGiftEvent message, IMessageHandlerContext context)
  {
    // TODO: register timeout for takeoff
    int year = DateTime.UtcNow.Year;
    await RequestTimeout(context, DateTimeOffset.Parse($"12/24/{year}"), new ChristmasEveTimeout());
  }

  public Task Timeout(ChristmasEveTimeout state, IMessageHandlerContext context)
  {
    // TODO: Time to take off! Send command for Rudolf to save the day!
    MarkAsComplete();
    return Task.CompletedTask;
  }
}

public class SleighTakeoffSagaData : ContainSagaData
{
  public Guid SleighId { get; init; }
}

public record ChristmasEveTimeout();
