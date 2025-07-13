using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    static Stack<int> torreA = new Stack<int>();
    static Stack<int> torreB = new Stack<int>();
    static Stack<int> torreC = new Stack<int>();
    static int numDiscos;

    static void MostrarTorres()
    {
        Console.WriteLine("Torre A: " + string.Join(",", torreA));
        Console.WriteLine("Torre B: " + string.Join(",", torreB));
        Console.WriteLine("Torre C: " + string.Join(",", torreC));
        Console.WriteLine("----------------------------------");
    }

    static void MoverDisco(Stack<int> origen, Stack<int> destino, char nombreOrigen, char nombreDestino)
    {
        int disco = origen.Pop();
        destino.Push(disco);
        Console.WriteLine($"Mover disco {disco} de torre {nombreOrigen} a torre {nombreDestino}");
        MostrarTorres();
    }

    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> auxiliar, Stack<int> destino,
                             char nombreOrigen, char nombreAuxiliar, char nombreDestino)
    {
        if (n == 1)
        {
            MoverDisco(origen, destino, nombreOrigen, nombreDestino);
            return;
        }

        ResolverHanoi(n - 1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);
        MoverDisco(origen, destino, nombreOrigen, nombreDestino);
        ResolverHanoi(n - 1, auxiliar, origen, destino, nombreAuxiliar, nombreOrigen, nombreDestino);
    }

    static void Main()
    {
        Console.Write("Ingrese el número de discos: ");
        numDiscos = int.Parse(Console.ReadLine());

        // Inicializar torre A con discos (de mayor a menor)
        for (int i = numDiscos; i >= 1; i--)
        {
            torreA.Push(i);
        }

        Console.WriteLine("Estado inicial:");
        MostrarTorres();

        ResolverHanoi(numDiscos, torreA, torreB, torreC, 'A', 'B', 'C');

        Console.WriteLine("¡Problema resuelto!");
    }
}

