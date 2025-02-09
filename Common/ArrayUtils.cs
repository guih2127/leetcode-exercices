namespace Common;

public static class ArrayUtils
{
    public static void PrintArray<T>(T[] array)
    {
        Console.WriteLine(String.Join(", ", array));
    }
}