/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки 
с наименьшей суммой элементов: 1 строка */

int[,] InitMatrix()
{
    int[,] matrix = new int[4,4];
    Random rnd = new Random();
    
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i,j] = rnd.Next(1,10);
        }
    }

    return matrix;
}
// тоже пустые строки между методами :)
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
int SumElements(int[] array)
{
    int sum=0;
    for (int i = 0; i < array.Length; i++) sum+=array[i];
    return sum;
}
int MinArray(int[]array) // советую называть методы более понятно. например это имя не говорит, что мы возвращаем именно индекс. GetIndexOfMinElement будет лучше
{
    int min= array[0]; // старайся одинаково проставлять пробельчики до и после операторов = < > и т.п. - хороший тон форматирования
    int minIndex=0;
    for (int i = 1; i < array.Length; i++) 
    {
        if (array[i]<min) 
        {
            min=array[i];
            minIndex=i;
        }
    }
    return minIndex;
}
int MinSum(int [,]matrix) // тут тоже не понятно по имени метода, что возвращается именно индекс :)
{
    // вместо создания массива сумм, можно старзу находить минимальную :)
    int[] sum = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        // я бы не стал создавать новый массив и копировать элементы каждый раз, когда нужно просуммировать строку.
        // Можно прямо в матрице, обращаясь ко всем [i, j] где i будет постоянно
        int [] array=new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)  array[j]=matrix[i,j];
        sum[i]=SumElements(array); // этот метод не нужен, есть встроенный array.Sum() (нужно добавить "using System.Linq;" в самом верху файла)
    }
    int minSum=MinArray(sum);
    return minSum; // можно написать просто return MinArray(sum);
}
int[,] matrix = InitMatrix();
PrintMatrix(matrix);
Console.WriteLine($"{MinSum(matrix)+1} строка с наименьшей суммой");
