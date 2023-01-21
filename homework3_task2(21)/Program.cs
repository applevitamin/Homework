// Задача 21
// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

Console.Clear(); //Очищаем консоль
// ТОчка А
Console.WriteLine("Введите координаты точки А по Х: ");
int x1 = int.Parse(Console.ReadLine()!); //Принимает число(координату точки А по Х)
Console.WriteLine("Введите координаты точки А по Y: ");
int y1 = int.Parse(Console.ReadLine()!); //Принимает число(координату точки А по Y)
Console.WriteLine("Введите координаты точки А по Z: ");
int z1 = int.Parse(Console.ReadLine()!); //Принимает число(координату точки А по Z)
//Точка В
Console.WriteLine("Введите координаты точки B по Х: ");
int x2 = int.Parse(Console.ReadLine()!); //Принимает число(координату точки А по Х)
Console.WriteLine("Введите координаты точки B по Y: ");
int y2 = int.Parse(Console.ReadLine()!); //Принимает число(координату точки А по Y)
Console.WriteLine("Введите координаты точки B по Z: ");
int z2 = int.Parse(Console.ReadLine()!); //Принимает число(координату точки А по Z)
// AB = √(xb - xa)2 + (yb - ya)2 + (zb - za)2
double result = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2) + Math.Pow(z1 - z2, 2));
result = Math.Round(result, 2, MidpointRounding.ToZero);
Console.WriteLine(result);
// задача 21 конец