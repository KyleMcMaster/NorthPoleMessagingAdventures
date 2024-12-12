using NorthPole.Core.Letters;

namespace NorthPole.Web.Letters;

public class Create : Endpoint<CreateLetterRequest>
{
  private readonly ILogger<Create> _logger;
  private readonly IMessageSession _messageSession;

  public Create(ILogger<Create> logger, IMessageSession messageSession)
  {
    _logger = logger;
    _messageSession = messageSession;
  }

  public override void Configure()
  {
    Post("/letters");
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateLetterRequest("Child's Name", "Magnetic Tiles");
    });
  }
    public override async Task HandleAsync(CreateLetterRequest req, CancellationToken cancellationToken)
    {
        _logger.LogInformation("North Pole received letter from {ChildName} asking for {Gift}, routing message to Santa's Inbox", req.ChildName, req.Gift);
        var message = new LetterToSanta(req.ChildName, req.Gift);
        await _messageSession.Send(message, cancellationToken);
    }
}

public record CreateLetterRequest(string ChildName, string Gift);
