using NorthPole.Core.Letters;

namespace NorthPole.Web.Letters;

public class Create : Endpoint<CreateLetterRequest>
{
  private readonly IMessageSession _messageSession;

  public Create(IMessageSession messageSession)
  {
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
        var message = new LetterToSanta(req.ChildName, req.Gift);
        await _messageSession.Send(message, cancellationToken);
    }
}

public record CreateLetterRequest(string ChildName, string Gift);
