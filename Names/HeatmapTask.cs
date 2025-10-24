namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var xLabels = new string[30];
        for (var i = 0; i < xLabels.Length; i++)
            xLabels[i] = (i + 2).ToString();

        var yLabels = new string[12];
        for (var i = 0; i < yLabels.Length; i++)
            yLabels[i] = (i + 1).ToString();

        var heatMap = new double[30, 12];
        foreach (var name in names)
            if (name.BirthDate.Day != 1)
                heatMap[name.BirthDate.Day - 2, name.BirthDate.Month - 1]++;

        return new HeatmapData(
            "Пример карты интенсивностей",
            heatMap,
            xLabels,
            yLabels);
    }
}