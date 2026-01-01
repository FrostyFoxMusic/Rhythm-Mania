using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace RhythmMania.Game;

public partial class Conductor : Node2D
{
	[Export] private PackedScene noteTrackPrefab;
	[Export] private Array<Key> trackKeys = [];

	//Temp configuration
	[Export] private int numberOfTracks = 4;
	[Export] private float targetDotPressedScaleMult = 1.2f;
	[Export] private float targetDotScreenEdgeVerticalOffset = 100f;

	private List<NoteTrack> NoteTracks { get; } = [];

	public override void _Ready()
	{
		SpawnNoteTracks();
	}

	private void SpawnNoteTracks()
	{
		float viewportWidth = GetViewportRect().Size.X;

		for (int i = 0; i < numberOfTracks; i++)
		{
			NoteTrack noteTrack = noteTrackPrefab.Instantiate<NoteTrack>();
			AddChild(noteTrack);
			NoteTracks.Add(noteTrack);

			float positionX = viewportWidth / -2 + (i + 1) * viewportWidth / (numberOfTracks + 1);
			noteTrack.Init(trackKeys[i], positionX, NoteFallType.Bottom, targetDotPressedScaleMult, targetDotScreenEdgeVerticalOffset);
		}
	}
}
