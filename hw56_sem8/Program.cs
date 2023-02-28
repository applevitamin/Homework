/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
*/


bool SearchRule(int rule, int leftValue, int rightValue)
{
    bool condition = false;
    switch (rule)
    {
        case 0:
            condition = leftValue > rightValue;
            break;
        case 1:
            condition = leftValue < rightValue;
            break;
    }
    return condition;
}


int FindIndexOfValue(int[] arrayOfSums, int searchOption)
{
    int tempIndex = 0;
    for (int index = 1; index < arrayOfSums.Length; index++)
    {
        bool rule = SearchRule(rule: searchOption,
                               leftValue: arrayOfSums[tempIndex],
                               rightValue: arrayOfSums[index]);
        if (rule) tempIndex = index;
    }

    return tempIndex;
}


(int, int) GetUsersSettings()
{
    Console.WriteLine();
    Console.Write("Выберите измерение для поиска суммы элементов:\n"
                + "1. По строкам\n"
                + "2. По колонкам\n\n"
                + "(для выбора укажите номер варианта цифрой, например: 1)\n"
                + ">>> ");
    bool validDimention = int.TryParse(Console.ReadLine()!, out int dimension);
    if (!validDimention
        || (dimension < 1 || 2 < dimension))
    {
        Console.WriteLine("Такого варианта не существует, будет использовано значение по умолчанию.");
        dimension = GetDefaultValues();
    }
    else dimension -= 1; // Кейсы вариантов сортировки начинаются с 0, а пользователь выбирает вариант от 1 до n!

    Console.WriteLine();
    string tempOutput = dimension == 1 ? "колонкам" : "строкам";
    Console.Write("Укажите параметр вывода:\n"
                    + $"1. Наименьшая сумма по {tempOutput}\n"
                    + $"2. Наибольшая сумма по {tempOutput}\n\n"
                    + "(для выбора укажите номер варианта цифрой, например: 1)\n"
                    + ">>> ");
    bool validSortDirection = int.TryParse(Console.ReadLine()!, out int outputParameter);
    if (!validSortDirection
        || (outputParameter < 1 || 2 < outputParameter))
    {
        Console.WriteLine("Такого варианта не существует, будет использовано значение по умолчанию.");
        outputParameter = GetDefaultValues();
    }
    else outputParameter -= 1; // Кейсы вариантов сортировки начинаются с 0, а пользователь выбирает вариант от 1 до n!

    return (dimension, outputParameter);
}


(int[], int, int) SumOfElementsLyingOnSameDimension(int[,] matrix)
{
    (int dimension, int parameter) userSearchSettings = GetUsersSettings();

    int mainDimensionLength, aggregateDimensionLength;
    bool horizontalDimension = userSearchSettings.dimension == 0;

    if (horizontalDimension)
    {
        mainDimensionLength = matrix.GetLength(0);
        aggregateDimensionLength = matrix.GetLength(1);
    }
    else
    {
        mainDimensionLength = matrix.GetLength(1);
        aggregateDimensionLength = matrix.GetLength(0);
    }

    int[] sumOfDimesion = new int[mainDimensionLength];
    for (int mainDimension = 0; mainDimension < mainDimensionLength; mainDimension++)
    {
        for (int aggregateDimension = 0; aggregateDimension < aggregateDimensionLength; aggregateDimension++)
        {
            if (horizontalDimension) sumOfDimesion[mainDimension] += matrix[mainDimension, aggregateDimension];
            else sumOfDimesion[mainDimension] += matrix[aggregateDimension, mainDimension];
        }
    }

    int indexOFValueYouLookingFor = FindIndexOfValue(sumOfDimesion, userSearchSettings.parameter);

    return (sumOfDimesion,
            indexOFValueYouLookingFor,
            userSearchSettings.dimension);
}


void Print2DArray(int[,] arrayToPrint)
{
    Console.WriteLine("\n");
    Console.WriteLine("Таблица значений:");
    for (int row = 0; row < arrayToPrint.GetLength(0); row++)
    {
        for (int column = 0; column < arrayToPrint.GetLength(1); column++)
        {
            Console.Write($"{arrayToPrint[row, column]}\t");
        }
        Console.WriteLine();
    }
}


void ShowResult(int[,] matrix, (int[] sumOfDimensions, int searchIndex, int dimention) args)
{
    Console.WriteLine("\n");
    Console.WriteLine("Таблица значений:");
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            Console.Write($"{matrix[row, column]}\t");
        }

        if (args.dimention == 0)
        {
            if (args.searchIndex == row) Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{'\u1405'}\t{args.sumOfDimensions[row]}");
            Console.ResetColor();
        }
        else Console.WriteLine();
    }
    if (args.dimention == 1)
    {
        for (int index = 0; index < args.sumOfDimensions.Length; index++)
        {
            if (args.searchIndex == index) Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{'\u1401'}\t");
            Console.ResetColor();
        }

        Console.WriteLine();

        for (int index = 0; index < args.sumOfDimensions.Length; index++)
        {
            if (args.searchIndex == index) Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{args.sumOfDimensions[index]}\t");
            Console.ResetColor();
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
            defaultValue = 4;
            break;
        case 1: // Количество столбцов матрицы
            defaultValue = 3;
            break;
        case 2: // Минимальное значение заполнения
            defaultValue = -10;
            break;
        case 3: // Максимальное значение заполнения
            defaultValue = 10;
            break;
        default:
            defaultValue = 0;
            break;
    }
    return defaultValue;
}


int[,] SetingsMenu()
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
            userConfiguredArray = GetFilledRandInt2DArray(userInputs);
            break;
    }
    return userConfiguredArray;
}


void Main()
{
    int[,] usersArray = SetingsMenu();
    Print2DArray(usersArray);
    (int[], int, int) resultTuple = SumOfElementsLyingOnSameDimension(usersArray);
    ShowResult(usersArray, resultTuple);
}


Main();