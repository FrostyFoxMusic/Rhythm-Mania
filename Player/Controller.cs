using Godot;

namespace RhythmMania.Player;

public partial class Controller : Node2D
{
	[Export] private float speed = 400f;

	public override void _Process(double delta)
	{
		Vector2 direction = Vector2.Zero;

		if (Input.IsActionPressed("ui_right"))
			direction.X += 1;
		if (Input.IsActionPressed("ui_left"))
			direction.X -= 1;
		if (Input.IsActionPressed("ui_down"))
			direction.Y += 1;
		if (Input.IsActionPressed("ui_up"))
			direction.Y -= 1;

		if (direction != Vector2.Zero)
		{
			direction = direction.Normalized();
			GetParent<Player>().Position += direction * speed * (float)delta;
		}
	}
}
