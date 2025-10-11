using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DistanceTask;

public static class DistanceTask
{
    // Длина отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetSideLength(double ax, double ay, double bx, double by)
    {
        return Math.Sqrt((ax-bx)*(ax-bx) + (ay-by)*(ay-by));
    }

    // Расстояние от точки C (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
    public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
    {
        var ab = GetSideLength(ax, ay, bx, by);
        var ca = GetSideLength(x, y, ax, ay);
        var cb = GetSideLength(x, y, bx, by);

        // Если точки A и B совпадают
        if (ab == 0)
            return ca;

        // Проверяем, можно ли опустить перпендикуляр из точки C к отрезку AB (проверка при помощи т. косинусов)
        if (ab * ab + cb * cb - ca * ca >= 0 && ab * ab + ca * ca - cb * cb >= 0)
        {
            var p = (ab + ca + cb) / 2.0;
            return 2 * Math.Sqrt(p * (p - ab) * (p - ca) * (p - cb)) / ab;
        }

        return Math.Min(ca, cb);
    }
}