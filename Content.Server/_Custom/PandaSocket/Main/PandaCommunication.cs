using System.Text.Json.Serialization;

namespace Content.Server._Custom.PandaSocket.Main;

public class PandaBaseMessage
{
    [JsonPropertyName("command")]
    public virtual string? Command { get; set; }
}

public class PandaBaseRequestEventMessage : PandaBaseMessage
{
    [JsonPropertyName("token")]
    public string? Token { get; set; }
}

public class UtkaOOCRequest : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "ooc";

    [JsonPropertyName("ckey")]
    public string? CKey { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

public class UtkaWhoRequest : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "who";
}

public class UtkaWhoResponse : PandaBaseMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "who";

    [JsonPropertyName("players")]
    public List<string>? Players { get; set; }
}

public class UtkaAdminWhoRequest : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "adminwho";
}

public class UtkaAdminWhoResponse : PandaBaseMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "adminwho";

    [JsonPropertyName("admins")]
    public List<string>? Admins { get; set; }
}

public class UtkaStatusRequest : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "status";
}

public class UtkaStatusResponse : PandaBaseMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "status";

    [JsonPropertyName("players")]
    public int? Players { get; set; }

    [JsonPropertyName("admins")]
    public int? Admins { get; set; }

    [JsonPropertyName("map")]
    public string? Map { get; set; }

    [JsonPropertyName("roundduration")]
    public double RoundDuration { get; set; }

    [JsonPropertyName("shuttlestatus")]
    public string? ShuttleStatus { get; set; }

    [JsonPropertyName("stationcode")]
    public string? StationCode { get; set; }
}

public sealed class UtkaRestartRoundRequest : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "restartround";
}

public sealed class UtkaRestartRoundResponse : PandaBaseMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "restartround";

    [JsonPropertyName("restarted")]
    public bool? Restarted { get; set; }
}

public sealed class UtkaBannedEvent : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "banned";

    [JsonPropertyName("ckey")]
    public string? Ckey { get; set; }

    [JsonPropertyName("ackey")]
    public string? ACkey { get; set; }

    [JsonPropertyName("bantype")]
    public string? Bantype { get; set; }

    [JsonPropertyName("duration")]
    public uint? Duration { get; set; }

    [JsonPropertyName("global")]
    public bool? Global { get; set; }

    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    [JsonPropertyName("rid")]
    public int? Rid { get; set; }

    [JsonPropertyName("banid")]
    public int? BanId { get; set; }
}

public sealed class UtkaChatMessageEvent : PandaBaseRequestEventMessage
{
    [JsonPropertyName("ckey")]
    public string? Ckey { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

public sealed class UtkaRoundStatusEvent : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "roundstatus";

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

public sealed class UtkaChatMeEvent : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "me";

    [JsonPropertyName("ckey")]
    public string? Ckey { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("character_name")]
    public string? CharacterName { get; set; }
}

public sealed class UtkaAhelpPmEvent : PandaBaseRequestEventMessage
{
    [JsonPropertyName("command")]
    public override string? Command => "pm";

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("ckey")]
    public string? Ckey { get; set; }

    [JsonPropertyName("sender")]
    public string? Sender { get; set; }

    [JsonPropertyName("rid")]
    public int? Rid { get; set; }

    [JsonPropertyName("no_admins")]
    public bool? NoAdmins { get; set; }

    [JsonPropertyName("entity")]
    public string? Entity { get; set; }
}
