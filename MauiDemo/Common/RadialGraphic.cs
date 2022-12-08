namespace MauiDemo.Common;

public class RadialGraphic : IDrawable
{
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Arc setup (both)
        canvas.StrokeSize = 45;
        canvas.BlendMode = BlendMode.Overlay;

        // Background Arc
        canvas.StrokeColor = Colors.Gray;
        canvas.DrawArc(45, 45, 100, 100, 230, -55, true, false);

        // Progress/top Arc
        canvas.StrokeColor = Colors.DarkOrange;
        canvas.DrawArc(45, 45, 100, 100, 230, 0, true, false);
    }
}