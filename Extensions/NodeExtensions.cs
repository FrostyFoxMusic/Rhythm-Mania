using Godot;

namespace RhythmMania.Extensions;

public static class NodeExtensions
{
	/// <summary>
	/// Gets the parent node of the specified type.
	/// </summary>
    public static T GetParentRecursive<T>(this Node node) where T : Node
	{
		Node current = node;
		while (current != null && current is not T)
			current = current.GetParent();

		if (current == null)
			return null;
		return current as T;
	}
}
