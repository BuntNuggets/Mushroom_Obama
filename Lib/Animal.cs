using Godot;
using System;

public partial class Animal : CharacterBody2D
{
    public enum PlayerDirection
    {
        LEFT,
        RIGHT
    }

    [ExportCategory("Movement")]
    [Export] private float JUMP_FORCE = -300f;
    [Export] private float ACCELERATION = 800f;
    [Export] private float MAX_SPEED = 200f;
    [Export] private float DRAG_FORCE = 0.2f;
    [Export] private int JUMPS = 1;

    [ExportCategory("Node References")]
    [Export] private AnimatedSprite2D animatedSprite;

    private PlayerDirection direction = PlayerDirection.RIGHT;
    private Vector2 movementInput = Vector2.Zero;
    private float gravity = 800f;
    private bool isGrounded = false;
    private bool directionChanged = false;
    private int jumpCounter = 0;

    public override void _Process(double delta)
    {
        base._Process(delta);
        isGrounded = IsOnFloor();
        moveCharacter(delta);
        directionChanged = (Velocity.X > 0 && movementInput.X < 0) || (Velocity.X < 0 && movementInput.X > 0) ? true : false;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        updateInputs();
        jumpUpdate();

        if((movementInput == Vector2.Zero && isGrounded) || directionChanged){
            applyLinearDrag();
        }

        if(!isGrounded){
            Vector2 velocity = Velocity;
            velocity.Y += gravity * (float) delta;
            Velocity = velocity;
        }

        if(Input.IsActionJustPressed("jump") && jumpCounter < JUMPS){
            jump();
        }

        MoveAndSlide();

    }

    private void updateInputs(){
        movementInput.X = Input.GetAxis("move_left", "move_right");

        if(movementInput.X != 0){
            if(movementInput.X < 0){
                direction = PlayerDirection.LEFT;
            }else{
                direction = PlayerDirection.RIGHT;
            }
        }

        if(direction == PlayerDirection.LEFT){
            animatedSprite.FlipH = true;
        }else{
            animatedSprite.FlipH = false;
        }

        if(movementInput.X != 0){
            animatedSprite.Play("move");
        }else{
            animatedSprite.Play("idle");
        }

    }

    private void jumpUpdate(){
        if(isGrounded){
            jumpCounter = 0;
        }
    }

    private void moveCharacter(double delta){
        Vector2 velocity = Velocity;
        velocity.X += movementInput.X * ACCELERATION * (float) delta;
        if(Mathf.Abs(velocity.X) > MAX_SPEED){
            velocity.X = MAX_SPEED * velocity.Normalized().X;
        }
        Velocity = velocity;
    }

    private void applyLinearDrag(){
        Vector2 velocity = Velocity;
        velocity.X *= 1-DRAG_FORCE;
        Velocity = velocity;
    }

    private void jump(){
        Vector2 velocity = Velocity;
        velocity.Y = JUMP_FORCE;
        jumpCounter++;
        Velocity = velocity;
    }


}
