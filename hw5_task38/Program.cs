// Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
// [3 7 22 2 78] -> 76




double[] randomArray(int size)
{
    double[] arr = new double[size];
    Random rand = new Random();

    for (int i = 0; i < size; i++)
    {
        arr[i] = rand.NextDouble() + rand.Next(-10, 10);
        arr[i] = Math.Round(arr[i], 3);
        Console.WriteLine($"{arr[i]}");
    }
    return arr;
}

void differenceMinMax(double[] array)
{
    double min = 0;
    double max = 0;
    foreach (double number in array)
    {
        if (min > number) min = number;
        if (max < number) max = number;
    }

    System.Console.WriteLine($"Минимальное число {min} Максимальное число {max} \n" +
    $"Разница между максимальным и минимальным числом {max - min}");
}

void main()
{
    Console.Clear();
    System.Console.Write("Введите размер массива:\t");
    int num = int.Parse(Console.ReadLine()!);
    differenceMinMax(randomArray(num));
}
main();