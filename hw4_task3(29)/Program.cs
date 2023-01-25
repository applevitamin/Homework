// Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.
// 1, 2, 5, 7, 19 -> [1, 2, 5, 7, 19]
// 6, 1, 33 -> [6, 1, 33]
string[] slog(string plup)
{
    string[] stady = new string[8];
    stady = plup.Split(","); // разделить строку с элементами через запятую.
    return stady;
}

void translate(string[] stady)
{
    System.Console.WriteLine(String.Join(", ", stady)); //String.Join соеденияет элементы строки разделяя символом.
}

void main()
{
    Console.WriteLine("Введите 8 чисел через запятую: ");
    string n = Console.ReadLine()!;
    translate(slog(n));
}

main();