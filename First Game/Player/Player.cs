using Godot;

public class Player : KinematicBody2D
{
    [Export] public float gravity = 1200.0f;
    [Export] public int walkSpeed = 600;
    [Export] public int jumpSpeed = -600;
    [Export] public float sprintBoost = 1.5f;

    Vector2 velocity = new Vector2();
    private bool jumping = false;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void getInput()
    {
        velocity.x = 0;

        bool sprint = Input.IsActionPressed("ui_select");

        bool left = Input.IsActionPressed("ui_left");
        bool right = Input.IsActionPressed("ui_right");    
        bool jump = Input.IsActionPressed("ui_up");
        bool pause = Input.IsActionPressed("ui_pause");
        bool shoot = Input.IsActionPressed("ui_fire");
        
        if (pause)
        {
            GetTree().ChangeScene("res://Main Screen/PauseScreen.tscn");
        }

        if (jump && IsOnFloor())
        {
            jumping = true;
            velocity.y = jumpSpeed;
        }

        if (left)
        {
            if (sprint)
            {
                velocity.x -= walkSpeed * sprintBoost;
            }
            else
            {
                velocity.x -= walkSpeed;
            }
        }

        if (right)
            if (sprint)
            {
                velocity.x += walkSpeed * sprintBoost;
            }
            else
            {
                velocity.x += walkSpeed;
            }
        
        var animatedSprite = GetNode<AnimatedSprite>("PlayerSprite");
         
        if (velocity.Length() > 0)
        {
            animatedSprite.Play();
        }
        else
        {
            animatedSprite.Stop();
        }
        
        if (velocity.x != 0)
        {
            animatedSprite.Animation = "Idle";
            // See the note below about boolean assignment
            animatedSprite.FlipH = velocity.x < 0;
            animatedSprite.FlipV = false;
        }
    }
    
    

    public override void _PhysicsProcess(float delta)
    {

        getInput();

        velocity.y += delta * gravity;

        if (jumping && IsOnFloor())
        {
            jumping = false;
        }

        velocity = MoveAndSlide(velocity, new Vector2(0, -1));

    }
}