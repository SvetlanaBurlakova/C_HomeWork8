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
            Console.Write($"{matrix[i,j]} ");
        }

        Console.WriteLine();
    }
}
int [] arraySort(int[] array)
{
for (int i = 0; i < array.Length - 1; i++)
{
    int maxPosition = i;
    for (int j = i+1; j < array.Length; j++)
    {
        if(array[j] > array[maxPosition]) maxPosition = j;
    }
    int temporary = array[i];
    array[i] = array[maxPosition];
    array[maxPosition] = temporary;
}
return array;
}
int [,] SortByRowsMatrix(int [,] matrix)
{
    int [,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int [] array=new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)  array[j]=matrix[i,j];
        array=arraySort(array);
        for (int j = 0; j < matrix.GetLength(1); j++)  result[i,j]=array[j];
    }
    return result;
}

int[,] matrix = InitMatrix();
PrintMatrix(matrix);
Console.WriteLine();
int[,] result = SortByRowsMatrix(matrix);
PrintMatrix(result);

