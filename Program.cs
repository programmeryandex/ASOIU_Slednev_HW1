// See https://aka.ms/new-console-template for more information
using System;

while (true)
{
    Console.Write("Введите первую строку (exit для выхода): ");
    string? s1 = Console.ReadLine();

    if (s1 == null)
    {
        Console.WriteLine("Ошибка ввода");
        continue;
    }

    if (s1.ToLower() == "exit")
        break;

    Console.Write("Введите вторую строку: ");
    string? s2 = Console.ReadLine();

    if (s2 == null)
    {
        Console.WriteLine("Ошибка ввода");
        continue;
    }

    int result = Distance(s1, s2);
    Console.WriteLine("Расстояние = " + result);
    Console.WriteLine();
}

static int Distance(string s1, string s2)
{
    int len1 = s1.Length;
    int len2 = s2.Length;

    int[,] matrix = new int[len1 + 1, len2 + 1];

    for (int i = 0; i <= len1; i++)
        matrix[i, 0] = i;

    for (int j = 0; j <= len2; j++)
        matrix[0, j] = j;

    for (int i = 1; i <= len1; i++)
    {
        for (int j = 1; j <= len2; j++)
        {
            int cost;

            if (s1[i - 1] == s2[j - 1])
                cost = 0;
            else
                cost = 1;

            int insert = matrix[i, j - 1] + 1;
            int delete = matrix[i - 1, j] + 1;
            int replace = matrix[i - 1, j - 1] + cost;

            matrix[i, j] = Math.Min(Math.Min(insert, delete), replace);
        }
    }

    return matrix[len1, len2];
}

