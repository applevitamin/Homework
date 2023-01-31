// Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.

// [345, 897, 568, 234] -> 2
Console.Clear();
Console.Write("Введите число эллементов массива:\t");
int[] array = new int[int.Parse(Console.ReadLine()!)];

bool Check(int n)
{
    if (n % 2 == 0)
    {
        return true;
    }

    return false;
}

Random rand = new Random();
int count = 0;
for (int i = 0; i < array.Length; i++)
{
    array[i] = rand.Next(100, 1000);
    Console.Write($"Число {array[i]} ");

    if (Check(array[i]))
    {
        Console.WriteLine($"Четное число!");
        count++;
    }

    else Console.WriteLine($"Не четное число!");
}

Console.WriteLine($"Четных чисел = {count}");