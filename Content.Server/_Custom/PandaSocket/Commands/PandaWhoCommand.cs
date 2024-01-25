using System.Linq;
using Content.Server._Custom.PandaSocket.Interfaces;
using Content.Server._Custom.PandaSocket.Main;
using Robust.Shared.Configuration;
using Robust.Shared.Enums;
using Robust.Shared.Player;

namespace Content.Server._Custom.PandaSocket.Commands;

public sealed class PandaWhoCommand : IPandaCommand
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    public string Name => "who";
    public Type RequestMessageType => typeof(UtkaWhoRequest);
    public void Execute(IPandaStatusHandlerContext context, PandaBaseMessage baseMessage)
    {
        if (baseMessage is not UtkaWhoRequest) return;

        IoCManager.InjectDependencies(this);

        var players = Filter.GetAllPlayers().ToList();
        var playerNames = players
            .Where(player => player.Status != SessionStatus.Disconnected)
            .Select(x => x.Name);

        var toUtkaMessage = new UtkaWhoResponse()
        {
            Players = playerNames.ToList()
        };

        Response(context, toUtkaMessage);
    }

    public void Response(IPandaStatusHandlerContext context, PandaBaseMessage? message = null)
    {
        context.RespondJsonAsync(message!);
    }
}
