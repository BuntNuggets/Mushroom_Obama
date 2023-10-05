using System.Reflection;
using Godot;

public partial class GameManager : Node
{
	//signals
	[Signal]
	public delegate void ToggleGamePausedEventHandler(bool is_paused);



	//note that public getters/setters means this is basically a global variable
	private bool _game_paused = false;
	public bool game_paused
	{
		get => _game_paused;
		set {
			_game_paused = value;
			GetTree().Paused = _game_paused;
			EmitSignal("ToggleGamePaused", _game_paused);
		}
	}
	//Public member functions0
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	public  override void _Input(InputEvent @event){
		if(@event.IsActionPressed("ui_cancel"))
			game_paused = !game_paused;
	}
}
