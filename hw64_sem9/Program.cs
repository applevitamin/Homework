/*
Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
N = 5 -> "5, 4, 3, 2, 1"
N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"
*/


string GetString(int usersNumber)
{

    if (usersNumber > 1) return usersNumber.ToString() + ", " + GetString(usersNumber - 1);
    else return usersNumber.ToString();
}


void Main()
{
    Console.Write("Введите число:\n>>> ");
    bool flag = int.TryParse(Console.ReadLine()!, out int number);
    if (flag) Console.WriteLine(GetString(number));
    else Console.WriteLine("Не удалось преобразовать введенный текст к числу, повторите попытку");
}

Main();