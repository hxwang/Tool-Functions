
//serialize
public static void SaveToFile<T>(this T obj, string filename)
{
	var xs = new XmlSerializer(typeof(T));
	using(var sw = new StreamWriter(filename))
	{
		xs.Serialize(sw, obj);
	}
}

public static T LoadObj<T>(string filename)
{
	var xs = new XmlSerializer(typeof(T));
	using (var sr = new StreamReader(filename))
	{
		var obj = xs.Deserialize(sr);
		return (T)obj;
	}
}