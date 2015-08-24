// Unity's mouse input requires hard-coded ints. This makes it more easier to read.

public enum MouseButtonType
{
	Left = 0,
	Right = 1,
	Middle = 2
}

public static class MouseButtons
{
	public const int Left = 0;
	public const int Right = 1;
	public const int Middle = 2;

	public static int Get(MouseButtonType button)
	{
		return (int) button;
	}
}


