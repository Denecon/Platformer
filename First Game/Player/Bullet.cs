using Godot;
using System;

public class Bullet : RigidBody2D
{
    public int speed = 1500;
    private Vector2 velocity = new Vector2();

    public void Start(Vector2 pos, float dir)
    {
        Rotation = dir;
        Position = pos;
        velocity = new Vector2(speed, 0).Rotated(Rotation);
    }
    
    public override void _Ready()
    {
        ApplyImpulse(velocity, velocity);
    }

    public override void _PhysicsProcess(float delta)
    {
        
    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
}
