using Godot;

namespace Scripts;

public partial class Main : Node
{
	[Export] private PackedScene mainMenuScene;

	public override void _Ready()
	{
		//Load Main Menu
		AddChild(mainMenuScene.Instantiate());
	}
}
