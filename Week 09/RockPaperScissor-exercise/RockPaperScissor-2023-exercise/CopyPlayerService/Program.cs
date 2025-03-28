﻿using EasyNetQ;
using Events;
using Helpers;
using OpenTelemetry;

namespace CopyPlayerService;

public static class Program
{
    private static readonly IPlayer Player = new CopyPlayer();
    
    public static async Task Main()
    {
        var connectionEstablished = false;

        while (!connectionEstablished)
        {
            var bus = ConnectionHelper.GetRMQConnection();
            var subscriptionResult = bus.PubSub.SubscribeAsync<GameStartedEvent>("RPS_" + Player.GetPlayerId(), e =>
            {
                e.ExtractPropagatedContext();
                var moveEvent = Player.MakeMove(e);
                bus.PubSub.PublishAsync(moveEvent);
            }).AsTask();

            await subscriptionResult.WaitAsync(CancellationToken.None);
            connectionEstablished = subscriptionResult.Status == TaskStatus.RanToCompletion;
            if(!connectionEstablished) Thread.Sleep(1000);
            
            bus.PubSub.SubscribeAsync<GameFinishedEvent>("RPS_" + Player.GetPlayerId(), e =>
            {
                e.ExtractPropagatedContext();
                Player.ReceiveResult(e);
            });
        }

        while (true) Thread.Sleep(5000);
    }
}