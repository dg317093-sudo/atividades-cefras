using System;
using System.Collections.Generic;
using System.Linq;

public class Processo
{
    public string Nome;
    public int Prioridade; 

    public Processo(string nome, int prioridade)
    {
        Nome = nome;
        Prioridade = prioridade;
    }
}

public class FilaPrioridade
{
    private List<Processo> fila = new List<Processo>();

    public void Enfileirar(Processo processo)
    {
        fila.Add(processo);

        fila = fila.OrderByDescending(p => p.Prioridade).ToList();
    }

    public Processo Desenfileirar()
    {
        if (fila.Count == 0)
            return null;

        Processo processo = fila[0];
        fila.RemoveAt(0);
        return processo;
    }

    public bool EstaVazia()
    {
        return fila.Count == 0;
    }
}

class Program
{
    static void Main()
    {
        FilaPrioridade cpu = new FilaPrioridade();

        cpu.Enfileirar(new Processo("Sistema - Atualização", 10));
        cpu.Enfileirar(new Processo("Usuário - Navegador", 3));
        cpu.Enfileirar(new Processo("Sistema - Antivírus", 8));
        cpu.Enfileirar(new Processo("Usuário - Jogo", 2));
        cpu.Enfileirar(new Processo("Usuário - Editor de Texto", 4));

        Console.WriteLine("=== Iniciando Simulação da CPU ===\n");

        while (!cpu.EstaVazia())
        {
            Processo atual = cpu.Desenfileirar();
            Console.WriteLine($"Executando processo: {atual.Nome} | Prioridade: {atual.Prioridade}");
        }

        Console.WriteLine("\n=== Todos os processos foram executados ===");
    }
}
