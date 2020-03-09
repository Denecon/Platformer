using Godot;
using System;

public class PauseScreen : MarginContainer
{
    
    [Signal]
    public delegate void Continue();
    
    
    private Vector2 screenSize; 
    
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    
    public void onContinuepressed()
    {
        GetTree().ChangeScene("res://World/Word.tscn");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
