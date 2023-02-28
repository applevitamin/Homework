/*
Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
*/


void PrintCube(int[,,] cubeToPrint)
{
    System.Console.WriteLine("\n");
    for (int heigh = 0; heigh < cubeToPrint.GetLength(2); heigh++)
    {
        Console.WriteLine($"{heigh + 1}-й Слой куба:");
        for (int depth = 0; depth < cubeToPrint.GetLength(1); depth++)
        {
            for (int width = 0; width < cubeToPrint.GetLength(0); width++)
            {
                Console.Write($"\t[{width}, {depth}, {heigh}] ->\t{cubeToPrint[width, depth, heigh]};");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}


int GetUniqRandIntValue(int[] arrayOfUniqueValues, int currentIndex,
                        int lBound, int uBound)
{
    Random randInt = new Random();
    int uniqueValue = randInt.Next(lBound, uBound + 1);

    while (Array.IndexOf(arrayOfUniqueValues, uniqueValue) != -1)
    {
        uniqueValue = randInt.Next(lBound, uBound + 1);
    }

    return uniqueValue;
}


int[,,] GetFilledIntCube((int widthLength, int depthLength,
                         int heightLength, int minVal,
                         int maxVal) args)
{
    int[,,] cubeToFill = new int[args.widthLength,
                                 args.depthLength,
                                 args.heightLength];
    int[] usedValues = new int[cubeToFill.Length];
    int indexUsedValues = 0;

    for (int width = 0; width < cubeToFill.GetLength(0); width++)
    {
        for (int depth = 0; depth < cubeToFill.GetLength(1); depth++)
        {
            for (int height = 0; height < cubeToFill.GetLength(2); height++)
            {
                cubeToFill[width, depth, height] = GetUniqRandIntValue(arrayOfUniqueValues: usedValues,
                                                                       currentIndex: indexUsedValues,
                                                                       lBound: args.minVal,
                                                                       uBound: args.maxVal);
                usedValues[indexUsedValues] = cubeToFill[width, depth, height];
                indexUsedValues++;
            }
        }
    }

    return cubeToFill;
}


int GetDefaultValues(int valueCode = -1)
{
    int defaultValue;
    switch (valueCode)
    {
        case 0: // Количество элементов по X-измерению
            defaultValue = 3;
            break;
        case 1: // Количество элементов по Y-измерению
            defaultValue = 3;
            break;
        case 2: // Количество элементов по Z-измерению
            defaultValue = 3;
            break;
        case 3:
            defaultValue = -27;
            break;
        case 4:
            defaultValue = 27;
            break;
        default:
            defaultValue = 0;
            break;
    }
    return defaultValue;
}


int[,,] SetupAndGetCube()
{
    int[,,] ourCube;
    (int xLength, int yLength, int zLength,
     int minVal, int maxVal) userInputs = (GetDefaultValues(0),
                                           GetDefaultValues(1),
                                           GetDefaultValues(2),
                                           GetDefaultValues(3),
                                           GetDefaultValues(4));
    Console.Write("Настроить создаваемый двумерный массив?\n(Y for Yes, Any key for No)\n>>> ");
    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.Y:
            Console.WriteLine("\n");
            Console.Write("Укажите ширину куба:\n>>> ");
            bool validWidth = int.TryParse(Console.ReadLine()!, out userInputs.xLength);
            if (!validWidth)
            {
                userInputs.xLength = GetDefaultValues(0);
                Console.WriteLine("Не удалось преобразовать введенную ширину куба к числу.\n"
                                + $"Будет использавоно значение по умолчанию –> {userInputs.xLength}");
                Console.WriteLine();
            }

            Console.Write("Укажите глубину куба:\n>>> ");
            bool validDepth = int.TryParse(Console.ReadLine()!, out userInputs.yLength);
            if (!validDepth)
            {
                userInputs.xLength = GetDefaultValues(0);
                Console.WriteLine("Не удалось преобразовать введенную глубину куба к числу.\n"
                                + $"Будет использавоно значение по умолчанию –> {userInputs.yLength}");
                Console.WriteLine();
            }

            Console.Write("Укажите высоту куба:\n>>> ");
            bool validHeight = int.TryParse(Console.ReadLine()!, out userInputs.zLength);
            if (!validHeight)
            {
                userInputs.xLength = GetDefaultValues(0);
                Console.WriteLine("Не удалось преобразовать введенную высоту куба к числу.\n"
                                + $"Будет использавоно значение по умолчанию –> {userInputs.zLength}");
                Console.WriteLine();
            }

            Console.Write("Укажите минимальное значение для заполнения куба:\n>>> ");
            bool validMinValue = int.TryParse(Console.ReadLine()!, out userInputs.minVal);
            if (!validMinValue)
            {
                userInputs.xLength = GetDefaultValues(0);
                Console.WriteLine("Не удалось преобразовать введеное значение заполнения к числу.\n"
                                + $"Будет использавоно значение по умолчанию –> {userInputs.minVal}");
                Console.WriteLine();
            }

            Console.Write("Укажите максимальное значение для заполнения куба:\n>>> ");
            bool validMaxValue = int.TryParse(Console.ReadLine()!, out userInputs.maxVal);
            if (!validMaxValue)
            {
                userInputs.xLength = GetDefaultValues(0);
                Console.WriteLine("Не удалось преобразовать введеное значение заполнения к числу.\n"
                                + $"Будет использавоно значение по умолчанию –> {userInputs.maxVal}");
                Console.WriteLine();
            }

            int minimumRequiredNumberOfValues = userInputs.xLength * userInputs.yLength * userInputs.zLength;
            int numberOfValues = userInputs.maxVal - userInputs.minVal;
            if (numberOfValues < minimumRequiredNumberOfValues)
            {
                int newUpperBound = userInputs.minVal + minimumRequiredNumberOfValues;
                Console.WriteLine($"В указанном Вами диапазоне [{userInputs.minVal}, {userInputs.maxVal + 1}), недостаточно уникальных "
                                + $"значений для заполнения куба [{userInputs.xLength} x {userInputs.yLength} x {userInputs.zLength}].\n"
                                + $"Диапазон значений будет расширен до -> [{userInputs.minVal}, {newUpperBound + 1})");
                userInputs.maxVal = newUpperBound;
            }

            ourCube = GetFilledIntCube(userInputs);
            break;
        default:
            ourCube = GetFilledIntCube(userInputs);
            break;
    }

    return ourCube;
}


void Main()
{
    int[,,] cube = SetupAndGetCube();
    PrintCube(cube);
}

Main();