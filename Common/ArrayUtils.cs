namespace Common;

public static class ArrayUtils
{
    public static void PrintArray<T>(T[] array)
    {
        Console.WriteLine(String.Join(", ", array));
    }
    
    public static void PrintDictionary<T,TS>(Dictionary<T,TS> dict)
    {
        Console.WriteLine(String.Join(", ", dict));
    }
}