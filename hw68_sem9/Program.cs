/*
Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два неотрицательных числа m и n.
m = 2, n = 3 -> A(m,n) = 9
*/


int A(int number, int multiplier)
{
    if (number == 0) return multiplier + 1;
    else if (multiplier == 0) return A(number - 1, 1);
    else return A(number - 1, A(number, multiplier - 1));
}



void Main()
{
    bool flag;
    Console.WriteLine("Функция Аккермана принимает два неотрицательных целых числа в качестве параметров \n"
                    + "и возвращает натуральное число, обозначается A(n,m)\n");
    Console.Write("Введите n:\n>>> ");
    flag = int.TryParse(Console.ReadLine()!, out int n);
    if (!flag)
    {
        Console.WriteLine("Не удалось преобразовать введенный текст к числу, повторите попытку");
        return;
    }
    Console.Write("Введите m:\n>>> ");
    flag = int.TryParse(Console.ReadLine()!, out int m);
    if (!flag)
    {
        Console.WriteLine("Не удалось преобразовать введенный текст к числу, повторите попытку");
        return;
    }

    Console.WriteLine($" A({n}, {m}) = {A(n, m)}");
}

Main();