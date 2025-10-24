namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var labels = new string[31];
        for (var i = 0; i < labels.Length; i++)
            labels[i] = (i + 1).ToString();
        
        var birthsCounts = new double[31];
        foreach (var n in names)
            if (n.Name == name && n.BirthDate.Day != 1)
                birthsCounts[n.BirthDate.Day - 1]++;

        return new HistogramData(
            $"Рождаемость людей с именем '{name}'",
            labels,
            birthsCounts);
    }
}