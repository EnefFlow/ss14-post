using System.Net;
using Content.Server._Custom.PandaSocket.Interfaces;
using Content.Server._Custom.PandaSocket.Main;
using Content.Server.Chat.Managers;

namespace Content.Server._Custom.PandaSocket.Commands;

public sealed class PandaSendOOCCommand : IPandaCommand
{
    public string Name => "ooc";
    public Type RequestMessageType => typeof(UtkaOOCRequest);
    public async void Execute(IPandaStatusHandlerContext context, PandaBaseMessage baseMessage)
    {
        if (baseMessage is not UtkaOOCRequest message) return;
        if(string.IsNullOrWhiteSpace(message.Message) || string.IsNullOrWhiteSpace(message.CKey)) return;

        var chatSystem = IoCManager.Resolve<IChatManager>();
        chatSystem.SendHookOOC($"{message.CKey}", $"{message.Message}");

        Response(context);
    }

    public async void Response(IPandaStatusHandlerContext context, PandaBaseMessage? message = null)
    {
        await context.RespondAsync("Success", HttpStatusCode.OK);
    }
}
