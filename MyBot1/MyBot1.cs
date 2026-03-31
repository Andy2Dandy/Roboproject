using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

// ------------------------------------------------------------------
// laminebot10
// ------------------------------------------------------------------
public class laminebot10 : Bot
{
    static void Main(string[] args)
    {
        new laminebot10().Start();
    }

    public override void Run()
    {
        // This makes the radar spin forever until it finds someone
        TurnRadarRight(double.PositiveInfinity);

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
        var enemyDirection = DirectionTo(evt.X, evt.Y);
        var gunTurn = CalcBearing(enemyDirection - GunDirection);
        TurnGunRight(gunTurn);

        // This locks the radar onto the enemy so we don't lose them
        var radarTurn = CalcBearing(enemyDirection - RadarDirection);
        TurnRadarRight(radarTurn);

        //uses the distance to decide bullet speed
        double distance = DistanceTo(evt.X, evt.Y);

        if (distance > 400)
        {
            Fire(1); // long range and fast bullet low dmg
        }
        else
        {
            Fire(2); // standard bullet
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

    public override void OnHitWall(HitWallEvent evt)
    {
        // When we hit a wall, back up and turn away
        Back(50);
        TurnRight(90);

        // how do i name bro laminebot10
    }
}