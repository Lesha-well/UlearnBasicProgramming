using System;

namespace Rectangles;

public static class RectanglesTask
{
    // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
    public static bool AreIntersected(Rectangle r1, Rectangle r2)
    {
        // Проверили, что прямоугольники НЕ пересекаются и вернули противоположное значение
        return ! (r1.Bottom < r2.Top || r1.Top > r2.Bottom || r1.Right < r2.Left || r1.Left > r2.Right);
    }

    // Площадь пересечения прямоугольников
    // Если прямоугольники пересекаются, то возвращаем произведение ширины на высоту пересечения
    public static int IntersectionSquare(Rectangle r1, Rectangle r2)
    {
        if (AreIntersected(r1, r2))
        {
            var intersectionWidth = Math.Max(r1.Left, r2.Left) - Math.Min(r1.Right, r2.Right);
            var intersectionHeight = Math.Max(r1.Top, r2.Top) - Math.Min(r1.Bottom, r2.Bottom);
            return intersectionWidth *  intersectionHeight;
        }
        return 0;
    }

    // Проверка, лежит ли прямоугольник внутри другого
    static bool IsInside(Rectangle inner, Rectangle outer)
    {
        return inner.Left >= outer.Left && inner.Right <= outer.Right && 
               inner.Top >= outer.Top && inner.Bottom <= outer.Bottom;
    }
    
    // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
    // Иначе вернуть -1
    // Если прямоугольники совпадают, можно вернуть номер любого из них.
    public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
    {
        if (IsInside(r1, r2))
            return 0;
        if (IsInside(r2, r1))
            return 1;
        return -1;
    }
}