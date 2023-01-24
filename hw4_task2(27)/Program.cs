// Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
// 452 -> 11
// 82 -> 10
// 9012 -> 12

void main()
{
    Console.WriteLine("Ввод: ");
    int num = int.Parse(Console.ReadLine()!);
    System.Console.WriteLine(supernum(num));
}
int supernum(int num)
{
int sum = 0;
    for (int i = 0; num > 0; i++)
    {
        sum = num % 10 + sum;
        num = num / 10;
    }
    return sum;
}
main();