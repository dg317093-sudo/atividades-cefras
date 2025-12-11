using System;
using System.IO; 
class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o caminho de uma pasta (ex: C:\\Windows\\Web ou . paratual):");
    string caminhoInicial = Console.ReadLine();
        if (caminhoInicial == ".") caminhoInicial = Directory.GetCurrentDirectory();
        try
        {
            Console.WriteLine($"\nExplorando: {caminhoInicial}\n");
            ExplorarDiretorios(caminhoInicial, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao acessar pasta: " + ex.Message);
        }
    }
    // Função Recursiva
    static void ExplorarDiretorios(string caminho, int nivel)
    {
        try
        {
            string indentacao = new string('-', nivel * 2);
            string[] arquivos = Directory.GetFiles(caminho);
            foreach (string arquivo in arquivos)
            {
                Console.WriteLine($"{indentacao} 📄 {Path.GetFileName(arquivo)}");
            }
            string[] subDiretorios = Directory.GetDirectories(caminho);
            foreach (string dir in subDiretorios)
            {
                Console.WriteLine($"{indentacao} 📁 [{Path.GetFileName(dir)}]");
                ExplorarDiretorios(dir, nivel + 1);
            }
        }
        catch (UnauthorizedAccessException)
        {
        }
    }
}