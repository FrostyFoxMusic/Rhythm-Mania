using System;
using Godot;
using RhythmMania.UI.MainMenu;
using RhythmMania.Game;

namespace RhythmMania.Base;

public partial class Main : Node
{
	private static Main Current { get; set; }
	public static event Action MainReady;

	private CanvasLayer CanvasLayer { get; set; }

	[Export] private PackedScene mainMenuScene;
	private bool IsMainMenuOpen { get; set; } = false;
	public MainMenu MainMenu { get; private set; }

	[Export] private PackedScene levelScene;
	private bool IsLevelLoaded { get; set; } = false;
	public Level Level { get; private set; }

	public override void _Ready()
	{
		Current = this;
		CanvasLayer = GetChild<CanvasLayer>(0);

		LoadMainMenu();
		MainReady?.Invoke();
	}

	public override void _Input(InputEvent e)
	{
		if (e is InputEventKey keyEvent && keyEvent.IsPressed() && keyEvent.Keycode == Key.Escape)
			LoadMainMenu();
	}

	public static void LoadLevel()
	{
		if (Current.IsLevelLoaded)
			return;

		Current.Level = Current.levelScene.Instantiate<Level>();
		Current.AddChild(Current.Level);
		Current.IsLevelLoaded = true;
	}

	public static void DisposeLevel()
	{
		if (!Current.IsLevelLoaded)
			return;

		Current.IsLevelLoaded = false;
		Current.Level.QueueFree();
		Current.Level = null;
	}

	public static void LoadMainMenu()
	{
		if (Current.IsMainMenuOpen)
			return;

		Current.MainMenu = Current.mainMenuScene.Instantiate<MainMenu>();
		Current.CanvasLayer.AddChild(Current.MainMenu);
		Current.IsMainMenuOpen = true;
	}

	public static void DisposeMainMenu()
	{
		if (!Current.IsMainMenuOpen)
			return;

		Current.IsMainMenuOpen = false;
		Current.MainMenu.QueueFree();
		Current.MainMenu = null;
	}
}
