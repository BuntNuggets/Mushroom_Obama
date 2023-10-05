using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Godot;

public partial class GameManager : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public  override void _Input(InputEvent @event){
		if(@event.IsActionPressed("ui_cancel")){
			GetTree().Paused = !GetTree().Paused;

		}


	}
}
