using Godot;
using System;

public class Pause : KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void getInput()
    {
        bool pause = Input.IsActionPressed("ui_pause");
        
        
    }
    
    public void onContinueButtonpressed()
    {
        GetNode<Control>("Pause").Hide();
        GetParent().GetParent().GetTree().Paused = false;
    }

    public override void _PhysicsProcess(float delta)
    {
        getInput();
    }
}
