using Godot;

public partial class Icon : Sprite2D
{
	Vector2 velocity = new Vector2(3,3);
	float width;
	float height;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		width = this.Texture.GetWidth();
		height = this.Texture.GetHeight();
	}

    public override void _Process(double delta)
    {
		float xrel = GetViewportRect().Position.X;
        if(Position.X + width / 2 > xrel + GetViewportRect().Size.X){
			velocity.X = -3;
		}
		float yrel = GetViewportRect().Position.Y;
        if(Position.Y + height/2 > yrel + GetViewportRect().Size.Y){
			velocity.Y = -3;
		}
		if(Position.X - width/2 < xrel){
			velocity.X = 3;
		}
		if(Position.Y - height/2 < yrel){
			velocity.Y = 3;
		}
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
	{
		this.Position += velocity;
	}
}
