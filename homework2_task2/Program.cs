﻿// Задача 13: Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет. (Цифры считать справа налево).

Console.Clear();
// 568 % 100 = 68, 68 / 10 = 6 | 56065 % 10000 = 6065 / 1000 = 6 | 56065 / 10000 Деление с остатком %()все что справа от запятой, деление на целые числа / (все что слева после запятой)
while (true)
{
    int num = new Random().Next(1, 100000);
    if (num >= 100) //автобус едет
    {
        int a1 = num % 1000 / 100;
        Console.WriteLine($"Третья цифра числа {num} справа {a1}");
        break;
    }
    else // Условия после else не указывается! Оно указано в If(В одной стороке)
    {
        Console.WriteLine("Третьей цифры нет!");
        continue;
    }
}