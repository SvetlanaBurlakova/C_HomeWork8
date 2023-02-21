/* Задайте две матрицы. Напишите программу, которая будет 
находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18 */
int GetNumber(string message)
{
    int value;
    Console.WriteLine(message);
    string str = Console.ReadLine();
    value = Convert.ToInt32(str);
    return value;
}
(int row1,int column1,int row2,int column2) GetMatrixesDimentions()
{
    int row1;
    int column1;
    int row2;
    int column2;
    while(true)
    {
        row1=GetNumber("Введите количество строк в матрице 1:");
        column1=GetNumber("Введите количество столбцов в матрице 1:");
        row2=GetNumber("Введите количество строк в матрице 2:");
        column2=GetNumber("Введите количество столбцов в матрице 2:");       
        if (column1==row2) break;
        else
        {
            Console.WriteLine("Произведение матриц указанной размерности найти не возможно, повторите ввод");
        }
    }
    return (row1, column1, row2, column2);
}
int[,] InitMatrix(int row,int column)
{
    int[,] matrix = new int[row,column];
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
int [,] MultMatrix(int [,] matrix1, int [,] matrix2)
{
    int [,] mult = new int[matrix1.GetLength(0),matrix2.GetLength(1)];
    int sum=0;
    for (int i = 0; i < mult.GetLength(0); i++)
    {
        for (int j = 0; j < mult.GetLength(1); j++)
        {
            for (int k = 0; k < matrix1.GetLength(1); k++) sum += matrix1[i,k]*matrix2[k,j];
            mult[i,j]=sum;
            sum=0;
        }
    }
    return mult;
}

(int row1,int column1,int row2,int column2) = GetMatrixesDimentions();

int [,] matrix1 =InitMatrix(row1,column1);
PrintMatrix(matrix1);
Console.WriteLine();

int [,] matrix2 =InitMatrix(row2,column2);
PrintMatrix(matrix2);
Console.WriteLine();

int [,] result = MultMatrix(matrix1, matrix2);
PrintMatrix(result);