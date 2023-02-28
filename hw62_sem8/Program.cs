/*
Задача 62: Заполните спирально массив 4 на 4.
*/


int[,] GetFilledRandIntMatrix((int rowsLength, int columnsLength) args)
{
    int[,] newMatrix = new int[args.rowsLength, args.columnsLength];
    int number = 1;

    int upperBoundary = 0;
    int rightBoundary = args.columnsLength - 1;
    int lowerBoundary = args.rowsLength - 1;
    int leftBoundary = 0;

    bool right = true;
    bool down = false;
    bool next = true;

    int row = 0;
    int column = 0;

    newMatrix[row, column] = number++;
    for (int i = 0; i < newMatrix.Length - 1; i++)
    {
        if (right && next)
        {
            newMatrix[row, ++column] = number++; // вправо
            down = !(column < rightBoundary); // когда дошли до проверенной границы, включаем вниз
            right = down ? !down : right; // выключаем вправо
            upperBoundary += down ? 1 : 0; // если прошли вправо, увеличиеваем верхнюю границу
        }
        else if (down)
        {
            newMatrix[++row, column] = number++; // вниз
            down = row < lowerBoundary; // когда дошли до проверенной границы, выключаем вниз
            rightBoundary -= !down ? 1 : 0; // если дошли вниз, увеличиваем нижнюю граниу
        }
        else if (!right)
        {
            newMatrix[row, --column] = number++; // влево
            right = leftBoundary == column; // когда дошли до проверенной границы, включаем вправо
            next = !right; // вправо включено, но на "следующий круг" еще рано, выключаем "следующий круг"
            lowerBoundary -= right ? 1 : 0; // если дошли влево, увеличиваем левую границу
        }
        else
        {
            newMatrix[--row, column] = number++; // вверх
            down = upperBoundary == row; // когда дошли до проверенной границы, выключаем вверх
            next = down; // пора на "следующий круг", "вправо" уже включено, включаем "следующий круг"
            leftBoundary += down ? 1 : 0; // если дошли вверх, увеличиваем левую границу
        }
    }

    return newMatrix;
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


int GetDefaultValues(int valueCode = -1)
{
    int defaultValue;
    switch (valueCode)
    {
        case 0: // Количество строк матрицы
            defaultValue = 4;
            break;
        case 1: // Количество столбцов матрицы
            defaultValue = 4;
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
    (int rows, int columns) userInputs = (GetDefaultValues(0),
                                          GetDefaultValues(1));
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

            userConfiguredArray = GetFilledRandIntMatrix(userInputs);

            break;

        default:
            userConfiguredArray = GetFilledRandIntMatrix(userInputs);
            break;
    }
    return userConfiguredArray;
}


void Main()
{
    int[,] usersArray = SetingsMenu();
    Print2DArray(usersArray);
}


Main();