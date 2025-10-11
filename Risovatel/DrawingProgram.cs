using System;
using Avalonia.Media;
using RefactorMe.Common;

namespace RefactorMe
{
    class Drawer
    {
        static float x, y;
        static IGraphics graphics;

        public static void Initialize ( IGraphics newGraphics )
        {
            graphics = newGraphics;
            graphics.Clear(Colors.Black);
        }

        public static void SetPosition(float x0, float y0)
        {
            x = x0;
            y = y0;
        }

        public static void DrawStep(Pen pen, double length, double angle)
        {
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Move(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle)); 
            y = (float)(y + length * Math.Sin(angle));
        }
    }
    
    public class ImpossibleSquare
    {
        private const float SegmentLength = 0.375f;
        private const float Offset = 0.04f;

        public static void DrawSide(int size, double value)
        {
            Drawer.DrawStep(new Pen(Brushes.Yellow), size * SegmentLength, value);
            Drawer.DrawStep(new Pen(Brushes.Yellow), size * Offset * Math.Sqrt(2), value + Math.PI / 4);
            Drawer.DrawStep(new Pen(Brushes.Yellow), size * SegmentLength, value + Math.PI);
            Drawer.DrawStep(new Pen(Brushes.Yellow), size * SegmentLength - size * Offset, value + Math.PI / 2);

            Drawer.Move(size * Offset, value - Math.PI);
            Drawer.Move(size * Offset * Math.Sqrt(2), value + 3 * Math.PI / 4);
        } 

        public static void Draw(int width, int height, IGraphics graphics)
        {

            Drawer.Initialize(graphics);

            var size = Math.Min(width, height);

            var diagonalLength = Math.Sqrt(2) * (size * SegmentLength + size * Offset) / 2;
            var x0 = (float)(diagonalLength * Math.Cos(Math.PI / 4 + Math.PI)) + width / 2f;
            var y0 = (float)(diagonalLength * Math.Sin(Math.PI / 4 + Math.PI)) + height / 2f;

            Drawer.SetPosition(x0, y0);

            DrawSide(size, 0);
            DrawSide(size, -Math.PI / 2);
            DrawSide(size, Math.PI);
			DrawSide(size, Math.PI / 2);
		}
    }
}