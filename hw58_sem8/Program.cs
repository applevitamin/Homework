/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/


int[,] GetProductOfTwoMatrices((int[,] firstMatrix, int[,] secondMatrix) args)
{

    int[,] resultOfProduct = new int[args.firstMatrix.GetLength(0), args.secondMatrix.GetLength(1)];

    for (int row = 0; row < args.firstMatrix.GetLength(0); row++)
    {
        for (int column = 0; column < args.secondMatrix.GetLength(1); column++)
        {
            for (int index = 0; index < args.firstMatrix.GetLength(1); index++)
                resultOfProduct[row, column] += args.firstMatrix[row, index] * args.secondMatrix[index, column];
        }
    }
    return resultOfProduct;
}


void Print2DArray(string output, int[,] arrayToPrint)
{
    Console.WriteLine("\n");
    Console.WriteLine($"{output}:");
    for (int row = 0; row < arrayToPrint.GetLength(0); row++)
    {
        for (int column = 0; column < arrayToPrint.GetLength(1); column++)
        {
            Console.Write($"{arrayToPrint[row, column]}\t");
        }
        Console.WriteLine();
    }
}


int[,] GetFilledRandInt2DArray((int rows, int columns, int minValue, int maxValue) args)
{
    int[,] int2DArray = new int[args.rows, args.columns];
    Random randInt = new Random();
    for (int row = 0; row < int2DArray.GetLongLength(0); row++)
    {
        for (int column = 0; column < int2DArray.GetLongLength(1); column++)
        {
            int2DArray[row, column] = randInt.Next(args.minValue, args.maxValue + 1);
        }
    }
    return int2DArray;
}


int GetDefaultValues(int valueCode = -1)
{
    int defaultValue;
    switch (valueCode)
    {
        case 0: // Количество строк матрицы
            defaultValue = 2;
            break;
        case 1: // Количество столбцов матрицы
            defaultValue = 2;
            break;
        case 2: // Минимальное значение заполнения
            defaultValue = 2;
            break;
        case 3: // Максимальное значение заполнения
            defaultValue = 5;
            break;
        default:
            defaultValue = 0;
            break;
    }
    return defaultValue;
}


int[,] SetingsMenu(bool firstDefault)
{
    int[,] userConfiguredArray;
    (int rows, int columns, int min, int max) userInputs = (GetDefaultValues(0),
                                                            GetDefaultValues(1),
                                                            GetDefaultValues(2),
                                                            GetDefaultValues(3));
    Console.Write("Настроить создаваемый двумерный массив?\n(Y for Yes, Any key for No)\n>>> ");
    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.Y:
            Console.WriteLine();
            Console.Write("Введите количество строк двумерного массива:\n>>> ");
            bool rowsValid = int.TryParse(Console.ReadLine()!, out userInputs.rows);
            if (!rowsValid)
            {
                userInputs.rows = GetDefaultValues(0);
                Console.WriteLine("Не удалось преобразовать введенное количество строк к числу.\n"
                                + $"Будет использовано значение по умолчанию –> {userInputs.rows}");
            }

            Console.Write("Введите количество столбцов двумерного массива:\n>>> ");
            bool columnsValid = int.TryParse(Console.ReadLine()!, out userInputs.columns);
            if (!columnsValid)
            {
                userInputs.columns = GetDefaultValues(1);
                Console.WriteLine("Не удалось преобразовать введенное количество столбцов к числу.\n"
                                + $"Будет использовано значение по умолчанию –> {userInputs.columns}");
            }

            Console.Write("Введите минимальное значение для заполнения двумерного массива:\n>>> ");
            bool minValid = int.TryParse(Console.ReadLine()!, out userInputs.min);
            if (!minValid)
            {
                userInputs.min = GetDefaultValues(2);
                Console.WriteLine("Не удалось преобразовать введенное минимальное значение для заполнения к числу.\n"
                                + $"Будет использовано значение по умолчанию –> {userInputs.min}");
            }

            Console.Write("Введите максимальное значение для заполнения двумерного массива:\n>>> ");
            bool maxValid = int.TryParse(Console.ReadLine()!, out userInputs.max);
            if (!maxValid)
            {
                userInputs.max = GetDefaultValues(3);
                Console.WriteLine("Не удалось преобразовать введенное максимальное значение для заполнения к числу.\n"
                                + $"Будет использовано значение по умолчанию –> {userInputs.max}");
            }

            userConfiguredArray = GetFilledRandInt2DArray(userInputs);

            break;

        default:
            if (firstDefault)
            {
                userConfiguredArray = new int[,]
                                    {
                                        {2, 4},
                                        {3, 2}
                                    };
            }
            else
            {
                userConfiguredArray = new int[,]
                                    {
                                        {3, 4},
                                        {3, 3}
                                    };
            }
            break;
    }
    return userConfiguredArray;
}


void Main()
{
    Console.WriteLine("Две матрицы можно перемножить между собой тогда и только тогда,\n"
                    + "когда количество столбцов первой матрицы равно количеству строк второй матрицы.");
    Console.WriteLine();
    int[,] firstFactor = SetingsMenu(true);
    Print2DArray("1-й множитель", firstFactor);
    int[,] secondFactor = SetingsMenu(false);
    Print2DArray("2-й множитель", secondFactor);

    int colCountFirstFactor = firstFactor.GetLength(1);
    int rowCountSecondFactor = secondFactor.GetLength(0);

    if (colCountFirstFactor != rowCountSecondFactor)
    {
        Console.WriteLine("Две матрицы можно перемножить между собой тогда и только тогда,\n"
                        + "когда количество столбцов первой матрицы равно количеству строк второй матрицы:\n"
                        + $"- количество столбцов первой матрицы -> {colCountFirstFactor}\n"
                        + $"- количеству строк второй матрицы-> {rowCountSecondFactor}");
        return;
    }
    int[,] product = GetProductOfTwoMatrices(
                                                (
                                                    firstMatrix: firstFactor,
                                                    secondMatrix: secondFactor
                                                )
                                            );
    Console.Clear();
    Print2DArray("1-й множитель", firstFactor);
    Print2DArray("2-й множитель", secondFactor);
    Print2DArray("Результат произведения 2-х матриц", product);
}


Main();