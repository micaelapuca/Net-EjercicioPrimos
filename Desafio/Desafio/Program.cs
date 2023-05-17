// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Funcion que obtiene los numeros primos de una cadena de texto.
int[] obtenerPrimos(string texto)
{
    List<int> primos = new List<int>();
    // Uso la biblioteca de regex para obtener los numeros de la cadena.
    Regex regex = new Regex(@"\d+");
    MatchCollection matches = regex.Matches(texto);
    // Recorro por cada numero obtenido en la cadena
    foreach (Match match in matches)
    {
        /* Teniendo en cuenta la cadena "123", se que voy a tener las combinaciones -> 1 12 123 / 2 23 / 3 
         El primer for lo uso para recorrer por cantidad de subcadenas. "123", "23", "3" */
        for (int i = 0; i < match.Value.Length; i++)
        {
            // El segundo for lo uso para desplazarme por los digitos de la subcadena.
            for (int j = 0; j < match.Value.Length - i; j++)
            {
                int num = int.Parse(match.Value.Substring(i, j + 1));
                if (EsPrimo(num) && !primos.Contains(num))
                {
                    primos.Add(num);
                }
            }
        }
    }
    return primos.ToArray();
}

// Funcion para validar si un numero es primo.
bool EsPrimo(int num)
{
    if (num <= 1)
    {
        return false;
    }
    int sqrtNum = (int)Math.Sqrt(num);
    for (int i = 2; i <= sqrtNum; i++)
    {
        if (num % i == 0)
        {
            return false;
        }
    }
    return true;
}

//Funcion que imprime con formato solicitado.
void primeNumberPrinter(string texto)
{
    int[] primos = obtenerPrimos(texto);
    if(primos.Length == 0)
    {
        Console.WriteLine("No se encontraron numeros primos en la cadena.");
        return;
    }
    Console.WriteLine("Los numeros primos hallados son los siguientes:");
    string cadena = string.Join(", ", primos);
    Console.Write("[ " + cadena + " ]" + " \n");
}

while (true)
{
    Console.WriteLine("Ingrese una cadena de texto:");
    string? texto = Console.ReadLine();
    if (texto == null)
    {
        return;
    }
    primeNumberPrinter(texto);
}


