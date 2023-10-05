	using Godot;

public partial class PauseMenu : Control
{
	[Export]
	GameManager game_manager;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
		//game_manager = (GameManager)GetNode("/root/Main"); -in case we don't want the export anymore
		game_manager.ToggleGamePaused += _OnGameManagerTogglePause;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _OnGameManagerTogglePause(bool is_paused){
		if(is_paused)
			Show();
		else
			Hide();
	}
	public void _OnResumeButtonPressed(){
		game_manager.game_paused = false;
	}
	public void _OnQuitButtonPressed(){
		//TODO: add a warning when quitting "unsaved data will be lost" popup
		GetTree().Quit();
	}

}
