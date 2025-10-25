using Godot;

namespace RhythmMania.Player;

public partial class Player : CharacterBody2D
{
	[Export] private float speed = 10f;
	[Export] private float jumpForce = 10f;
	[Export] private float gravity = 9.8f;
	[Export] private float xDrag = 0.1f;
	private bool IsGrounded { get; set; }

	private Sprite2D Sprite { get; set; }

	public override void _Ready() =>
		Sprite = GetChild<Sprite2D>(2);

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = Vector2.Zero;
		//Set gravity to 9.8m/s2 (accelerating downwards)
		direction.Y += gravity;

		if (Input.IsActionPressed("ui_right"))
		{
			direction.X += 1;
			Sprite.FlipH = false;
		}

		if (Input.IsActionPressed("ui_left"))
		{
			direction.X -= 1;
			Sprite.FlipH = true;
		}

		if (Input.IsActionPressed("ui_up") && IsGrounded)
		{
			direction.Y -= jumpForce;
			IsGrounded = false;
		}

		if (direction != Vector2.Zero)
		{
			Velocity += direction * speed;
			Velocity *= (1 - xDrag);
			MoveAndSlide();
			if (Velocity.Y == 0)
				IsGrounded = true;
		}
		if (Position.Y > 1000)
		{
			Position = Vector2.Zero;
		}

	}
}
