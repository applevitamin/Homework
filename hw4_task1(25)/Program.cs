// Задача 25: Напишите функцию, которая принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
// Нельзя использовать библиотеку Math!
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16
void main()
{
    Console.Clear();
    System.Console.WriteLine("Введите число А: ");
    int first = int.Parse(Console.ReadLine()!);
    System.Console.WriteLine("Введите число В: ");
    int second = int.Parse(Console.ReadLine()!);
    Console.WriteLine($"Возвели число {first} в степень числа {second} получили {cucumbers(first, second)}");
}

int cucumbers(int a, int b)
{
    int result = 1;

    for(int i = 0; i < b; i++)
    {
        result *= a;
    }
    return result;
}

main();




// Console.WriteLine($"Число {first} и число {Math.Pow(first, second)}");