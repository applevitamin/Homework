Console.Clear();
Console.WriteLine("Введите номер дня недели: ");
int day = int.Parse(Console.ReadLine()!);
if(day >= 1 && day <= 7)
{
    if (day <= 5) Console.WriteLine($"Введенный Вами номер недели |{day}| является будним днем, нужно на работу =(");
    else Console.WriteLine($"Введенный Вами номер недели |{day}| является выходным, Ура!");
}
else Console.WriteLine($"Ты что?! {day} дня в недели не бывает!");