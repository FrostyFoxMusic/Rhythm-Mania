using Godot;

namespace RhythmMania.Game;

public partial class NoteTrack : Node2D
{
	[Export] private PackedScene blueDotPrefab;
	[Export] private PackedScene greenDotPrefab;
	[Export] private PackedScene redDotPrefab;
	[Export] private PackedScene magentaDotPrefab;

	[Export] private PackedScene targetDotPrefab;


	private Node2D TargetDot { get; set; }
	private Vector2 TargetDotScale { get; set; }
	private float TargetDotPressedScaleMult { get; set; }
	private Key Key { get; set; }
	private NoteFallType NoteFallType { get; set; }

	public void Init(Key key, float positionX, NoteFallType noteFallType, float targetDotPressedScaleMult, float targetDotScreenEdgeVerticalOffset)
	{
		Key = key;
		NoteFallType = noteFallType;

		float positionY = (GetViewportRect().Size.Y / 2 - targetDotScreenEdgeVerticalOffset) * (int)NoteFallType;
		Position = new(positionX, positionY);

		TargetDotPressedScaleMult = targetDotPressedScaleMult;
	}

	public override void _Ready()
	{
		TargetDot = targetDotPrefab.Instantiate<Node2D>();
		AddChild(TargetDot);
		TargetDotScale = TargetDot.Scale;
	}

	public override void _Process(double delta)
	{

	}

	public override void _Input(InputEvent e)
	{
		if (e is InputEventKey eventKey && eventKey.Pressed && eventKey.Keycode == Key)
		{
			GD.Print($"Hit note track with key {Key}");
			TargetDot.Scale = TargetDotScale * TargetDotPressedScaleMult;
		}
		else
		{
			TargetDot.Scale = TargetDotScale;
		}
	}
}
