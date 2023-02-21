/* Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */

int[,,] InitMatrix()
{
    int[,,] matrix = new int[2,2,2];
    Random rnd = new Random();
    int number;
    int[] numbers = new int [8];
    int count =0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                number=rnd.Next(10,100);
                
                while (Array.Exists(numbers,x=> x==number)) 
                {
                     number=rnd.Next(10,100);   
                }
                matrix[i,j,k] = number;
                numbers[count]=number;
                count +=1;
            }
        }
    }
    return matrix;
}
void PrintMatrix(int[,,] matrix)
{
    for (int k = 0; k < matrix.GetLength(0); k++)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(2); j++)
            {
                Console.Write($"{matrix[i,j,k]}({i},{j},{k}) ");
            }
        Console.WriteLine();
        }
    }
}
int [,,] matrix =InitMatrix();
PrintMatrix(matrix);