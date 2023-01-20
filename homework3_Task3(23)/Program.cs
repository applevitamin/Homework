// Задача 23: Напишите программу, которая принимает на
// вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 4, 9.
// 5 -> 1, 8, 27, 64, 125

Console.Clear();
Console.WriteLine("Введите любое число, для вывода числе кубов");
int num = int.Parse(Console.ReadLine()!);
int num1 = 1;
while(num1 <= num)
{
    Console.Write($"{Math.Pow(num1, 3)}");
    if( num1 != num) Console.Write(" | ");
    num1++;
}