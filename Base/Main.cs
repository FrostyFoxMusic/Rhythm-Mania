using System;
using Godot;
using RhythmMania.UI.MainMenu;

namespace RhythmMania.Base;

public partial class Main : Node
{
	private static Main Current { get; set; }
	public static event Action MainReady;

	private CanvasLayer CanvasLayer { get; set; }

	[Export] private PackedScene mainMenuScene;
	private bool IsMainMenuOpen { get; set; } = false;
	public MainMenu MainMenu { get; private set; }


	public override void _Ready()
	{
		Current = this;
		CanvasLayer = GetChild<CanvasLayer>(0);

		OpenMainMenu();
		MainReady?.Invoke();
	}

	public override void _Input(InputEvent e)
	{
		if (e is InputEventKey keyEvent && keyEvent.IsPressed() && keyEvent.Keycode == Key.Escape)
			OpenMainMenu();
	}

	public static void OpenMainMenu()
	{
		if (Current.IsMainMenuOpen)
			return;

		Current.MainMenu = Current.mainMenuScene.Instantiate<MainMenu>();
		Current.CanvasLayer.AddChild(Current.MainMenu);
		Current.IsMainMenuOpen = true;
	}

	public static void CloseMainMenu()
	{
		if (!Current.IsMainMenuOpen)
			return;

		Current.IsMainMenuOpen = false;
		Current.MainMenu.QueueFree();
		Current.MainMenu = null;
	}
}
