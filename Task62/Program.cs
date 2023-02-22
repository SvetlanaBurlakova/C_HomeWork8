/* Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */
int[,] InitMatrix()
{
    int[,] matrix = new int[4,4];
    int number=1;  
    int count=0;
    // 1) интересный способ :D я бы использовал что-то типа diameterNumber.
    // 2) вместо matrix.GetLength(0)*matrix.GetLength(1) можно просто matrix.Length - это то же самое
    while (number<=matrix.GetLength(0)*matrix.GetLength(1))
    {
        for (int j = count; j < matrix.GetLength(1)-count; j++)
        {
            matrix[count,j] = number;
            number+=1;
        }
        count+=1; // можно написать без этой переменной вообще, попробуй) она лишняя
        for (int j = count; j <= matrix.GetLength(0)-count; j++)
        {
            matrix[j,matrix.GetLength(1)-count] = number;
            number+=1;
        }
        for (int j=matrix.GetLength(1)-1-count; j >= count-1; j--)
        {
            matrix[matrix.GetLength(0)-count,j] = number;
            number+=1;
        }
        for (int j=matrix.GetLength(0)-1-count; j >= count; j--)
        {
            matrix[j,count-1] = number;
            number+=1;
        }
    }
    return matrix;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]:00} ");
        }

        Console.WriteLine();
    }
}
int [,] matrix = InitMatrix();
PrintMatrix(matrix);
