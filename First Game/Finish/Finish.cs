using Godot;
using System;

public class Finish : Area2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    public void onFinishareaentered(PhysicsBody2D body)
    {
        GetTree().ChangeScene("res://Main Screen/MainScreen.tscn");
    }
}
