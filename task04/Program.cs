// Задача 8: Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N.

// 5 -> 2, 4
// 8 -> 2, 4, 6, 8
Console.Write("Введите число: ");
int number = int.Parse(Console.ReadLine()!);
int depo = 2;
while (depo <= number)
{
        Console.Write($"{depo} | ");
depo+=2; // только четные с шагом в 2
}