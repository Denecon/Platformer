using Godot;
using System;

public class Coin : Area2D
{

    [Signal]
    public delegate void CoinPickup();
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void onCoinbodyentered(PhysicsBody2D body)
    {
        Hide();
        EmitSignal("CoinPickup");
        GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
    }
}
