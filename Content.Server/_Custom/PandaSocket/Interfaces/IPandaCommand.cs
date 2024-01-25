using Content.Server._Custom.PandaSocket.Main;

namespace Content.Server._Custom.PandaSocket.Interfaces;

public interface IPandaCommand
{
    string Name { get; }
    Type RequestMessageType { get; }
    public void Execute(IPandaStatusHandlerContext context, PandaBaseMessage baseMessage);
    public void Response(IPandaStatusHandlerContext context, PandaBaseMessage? message = null);
}
