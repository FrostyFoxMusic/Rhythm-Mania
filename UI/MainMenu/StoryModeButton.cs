using Godot;
using RhythmMania.Base;
//using RhythmMania.Extensions;

namespace RhythmMania.UI.MainMenu;

public partial class StoryModeButton : Button
{
	//private MainMenu MainMenu { get; set; }

	public override void _Ready()
	{
		//MainMenu = this.GetParentRecursive<MainMenu>();
	}

	public override void _Pressed()
	{
		Main.DisposeMainMenu();
		Main.LoadLevel();
	}
}
