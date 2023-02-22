/*
Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

int[,] InitMatrix()
{
    int[,] array = new int[4,4];
    Random rnd = new Random();
    
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = rnd.Next(1,10);
        }
    }

    return array;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} "); // образуется лишний пробел в конце, но тут это не критично
        }

        Console.WriteLine();
    }
}
// старайся добавлять пустые строки между функциями - хороший тон форматирования
int [] arraySort(int[] array) // старайся придерживаться одинакового кейсинга названий методов - с большой буквы (тоже хороший тон)
{
// старайся внутри {} добавлять оффсет - тоже хороший тон
for (int i = 0; i < array.Length - 1; i++)
{
    int maxPosition = i;
    for (int j = i+1; j < array.Length; j++)
    {
        if(array[j] > array[maxPosition]) maxPosition = j;
    }
    // 1) чисто для информации, в C# вместо 3х следующих строк можно написать так:
    //    (array[i], array[maxPosition]) = (array[maxPosition], array[i]);
    // 2) если maxPosition остался равным i, то подмену производить не нужно
    int temporary = array[i];
    array[i] = array[maxPosition];
    array[maxPosition] = temporary;
}
return array; // не имеет смысла возвращать массив, потому что ты и так меняешь содержимое переданного массива, а массиввы всегда by-reference передаются
}
int [,] SortByRowsMatrix(int [,] matrix)
{
    int [,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
    // если результат не зависит от направления, то всегда лучше в обратную сторону, например for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
    // потому что в таком варианте метод matrix.GetLength(0) вызовется только один раз (в начале цикла) а не в каждой итерации
    // плюс сравнение с нулём всегда эффективнее чем сравнение с другим числом
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int [] array=new int[matrix.GetLength(1)]; // этот массив можно создать 1 раз до цикла, а не создавать внутри каждой итерации, он же перетирается полностью
        for (int j = 0; j < matrix.GetLength(1); j++)  array[j]=matrix[i,j];
        array=arraySort(array); // вот тут заместо ручной сортировки можно написать Array.Sort(array, (a, b) => b.CompareTo(a));
        for (int j = 0; j < matrix.GetLength(1); j++)  result[i,j]=array[j];
    }
    return result;
}

int[,] matrix = InitMatrix();
PrintMatrix(matrix);
Console.WriteLine();
int[,] result = SortByRowsMatrix(matrix);
PrintMatrix(result);

