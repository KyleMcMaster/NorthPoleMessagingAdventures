using NorthPole.Core.Letters;

namespace NorthPole.Web.Letters;

public record CreateLetterRequest(string ChildName, string Present);

public class Create(ILogger<Create> logger, IMessageSession messageSession) : Endpoint<CreateLetterRequest>
{
  private readonly ILogger<Create> _logger = logger;
  private readonly IMessageSession _messageSession = messageSession;

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
        _logger.LogInformation("North Pole received letter from {ChildName} asking for {Present}, routing message to Santa's Inbox", req.ChildName, req.Present);
        var message = new LetterToSanta(req.ChildName, req.Present);
        await _messageSession.Send(message, cancellationToken);
    }
}

