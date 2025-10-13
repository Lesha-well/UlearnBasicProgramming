namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
		var mod10 = count % 10;
		var mod100 = count % 100;
		
		if (mod10 == 1 && mod100 != 11)
			return "рубль";
		if (mod10 >= 2 && mod10 <= 4 && (mod100 < 10 || mod100 >= 20))
			return "рубля";
		return "рублей";
	}
}