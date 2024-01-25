using System.Linq;
using Content.Server._Custom.PandaSocket.Interfaces;
using Content.Server._Custom.PandaSocket.Main;
using Content.Server.Administration.Managers;

namespace Content.Server._Custom.PandaSocket.Commands;

public sealed class PandaAdminWhoCommand : IPandaCommand
{
    public string Name => "adminwho";
    public Type RequestMessageType => typeof(UtkaAdminWhoRequest);
    public void Execute(IPandaStatusHandlerContext context, PandaBaseMessage baseMessage)
    {
        if(baseMessage is not UtkaAdminWhoRequest message) return;
        IoCManager.InjectDependencies(this);

        var adminManager = IoCManager.Resolve<IAdminManager>();

        var admins = adminManager.ActiveAdmins.ToList();

        var adminsList = new List<string>();

        foreach (var admin in admins)
        {
            adminsList.Add(admin.Name);
        }

        var toUtkaMessage = new UtkaAdminWhoResponse()
        {
            Admins = adminsList
        };

        Response(context, toUtkaMessage);
    }

    public void Response(IPandaStatusHandlerContext context, PandaBaseMessage? message = null)
    {
        context.RespondJsonAsync(message!);
    }
}
