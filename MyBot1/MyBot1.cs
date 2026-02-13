using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

// ------------------------------------------------------------------
// MyFirstBot
// ------------------------------------------------------------------
// A sample bot originally made for Robocode by Mathew Nelson.
//
// Probably the first bot you will learn about.
// Moves in a seesaw motion and spins the gun around at each end.
// ------------------------------------------------------------------

public class MyBot1 : Bot
{
    static void Main(string[] args)
    {
        new MyBot1().Start();
    }

    public override void Run()
    {
        while (IsRunning)
        {
            // move foward and stops when sum happens
            Forward(400);

            // turn the gun 360
            TurnGunLeft(360);

            // this backs it moves backwards
            Back(400);
            TurnGunRight(360);
        }
    }

    public override void OnScannedBot(ScannedBotEvent evt)
    {
        //this getswhere the enmy is
        var bearing = BearingTo(evt.X, evt.Y);
        TurnGunRight(bearing);

        //uses the distance to decide bullet speed
        double distance = DistanceTo(evt.X, evt.Y);

        if (distance < 200)
        {
            Fire(3); //close range and high dmg slow bullet
        }
        else
        {
            Fire(1); // long range and fast bullet low dmg
        }
    }

    public override void OnHitByBullet(HitByBulletEvent evt)
    {
        //when the bullet is gong toward mybot it will move.
        var bearing = CalcBearing(evt.Bullet.Direction);

        // Turn perpendicular to the op and run like lamine or balde.
        TurnRight(90 - bearing);
        Forward(100);

        //lamine the goat still btw
    }
}
