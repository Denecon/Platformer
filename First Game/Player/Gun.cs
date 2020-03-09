using Godot;
using System;

public class Gun : KinematicBody2D
{
    private PackedScene bullet = (PackedScene) GD.Load("res://Player/Bullet.tscn");

    private bool canFire = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    
    
    public void GetInput()
    {
        bool shoot = Input.IsActionPressed("ui_fire");
    
        if (shoot && canFire)
        {
            canFire = false;
            Fire();
            delayOfFire();
        }
    }

    public void Fire()
    {

        
        var barrel = (Bullet)bullet.Instance();
        barrel.Start(GetNode<Node2D>("Muzzle").GlobalPosition, Rotation);
        GetParent().GetParent().AddChild(barrel);
    }
    
    private async void delayOfFire()
    {
        var RateOfFire = (Timer) GetNode("RateOfFire");
        await ToSignal(RateOfFire, "timeout");
    }

    public void onRateOfFiretimeout()
    {
        canFire = true;
    }

    public override void _Process(float delta)
    { 
        GetInput();
        var dir = GetGlobalMousePosition() - GlobalPosition;
        if (dir.Length() > 5)
        {
            Rotation = dir.Angle();
        }
    }
}
