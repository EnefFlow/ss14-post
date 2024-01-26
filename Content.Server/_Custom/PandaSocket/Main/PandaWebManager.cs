﻿using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using Content.Shared.CCVar;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Robust.Shared.Configuration;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Content.Server._Custom.PandaSocket.Main;

public sealed class PandaWebManager
{
    [Dependency] private readonly IConfigurationManager _cfg = default!;

    private readonly HttpClient _httpClient = new();
    private string? _token;
    private string? _utkaUri;

    public void Initialize()
    {
        IoCManager.InjectDependencies(this);

        _token = _cfg.GetCVar(CCVars.PandaToken);
        _cfg.OnValueChanged(CCVars.PandaToken, token => _token = token, true);

        _utkaUri = _cfg.GetCVar(CCVars.UtkaClientBind);
        _cfg.OnValueChanged(CCVars.UtkaClientBind, uri => _utkaUri = uri, true);
    }

    public async void SendBotGetMessage(PandaBaseMessage message)
    {
        if (_utkaUri is null || _token is null)
            return;

        var json = JsonSerializer.Serialize(message, message.GetType());
        var jObj = (JObject) JsonConvert.DeserializeObject(json)!;
        var query = String.Join("&",
            jObj.Children().Cast<JProperty>()
                .Select(jp=>jp.Name + "=" + HttpUtility.UrlEncode(jp.Value.ToString())));

        var request = $"{_utkaUri}?token={_token}&{query}";

        try
        {
            await _httpClient.GetAsync(request);
        }
        catch (Exception e)
        {
            return;
        }
    }

    public async void SendBotPostMessage(PandaBaseRequestEventMessage message)
    {
        if (_utkaUri is null || _token is null)
            return;

        message.Token = _token;

        var request = _utkaUri;
        var json = JsonSerializer.Serialize(message, message.GetType());

        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            await _httpClient.PostAsync(request, content);
        }
        catch (Exception e)
        {
            return;
        }
    }
}
