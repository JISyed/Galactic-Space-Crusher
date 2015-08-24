using UnityEngine;

public class ChangeMouseCursor : MonoBehaviour 
{
	public Texture2D mousePointer;
	public Vector2 hotspot;
	public CursorMode cursorMode;

	// Use this for initialization
	void Start () 
	{
		Cursor.SetCursor(mousePointer, hotspot, cursorMode);
	}

	void OnDestroy()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
