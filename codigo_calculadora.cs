using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcEstatSwitchCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numeros = new double[100]; // Vetor para armazenar até 100 números
            int quantidade = 0; // Contador de quantos números foram inseridos
            int opcao;

            // Menu principal
            do
            {
                Console.WriteLine("\n=== Calculadora de Estatísticas ===");
                Console.WriteLine("1 - Inserir números um a um");
                Console.WriteLine("2 - Inserir números separados por vírgula");
                Console.WriteLine("3 - Calcular estatísticas");
                Console.WriteLine("4 - Limpar dados");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        // Leitura de números um a um
                        Console.WriteLine("\nDigite um número (ou -999 para parar):");
                        double num = double.Parse(Console.ReadLine());

                        while (num != -999 && quantidade < 100)
                        {
                            numeros[quantidade] = num;
                            quantidade++;
                            Console.WriteLine("Digite outro número (ou -999 para parar):");
                            num = double.Parse(Console.ReadLine());
                        }
                        break;

                    case 2:
                        // Leitura de números separados por vírgula
                        Console.WriteLine("\nDigite os números separados por vírgula:");
                        string entrada = Console.ReadLine();
                        string[] numerosTexto = entrada.Split(',');

                        quantidade = 0;
                        for (int i = 0; i < numerosTexto.Length && i < 100; i++)
                        {
                            numeros[quantidade] = double.Parse(numerosTexto[i].Trim());
                            quantidade++;
                        }
                        break;

                    case 3:
                        // Cálculo da média
                        double soma = 0;
                        for (int i = 0; i < quantidade; i++)
                        {
                            soma += numeros[i];
                        }
                        double media = soma / quantidade;

                        // Encontra valor máximo e mínimo
                        double maximo = numeros[0];
                        double minimo = numeros[0];
                        for (int i = 1; i < quantidade; i++)
                        {
                            if (numeros[i] > maximo) maximo = numeros[i];
                            if (numeros[i] < minimo) minimo = numeros[i];
                        }

                        // Ordenação do vetor para calcular a mediana (usando bubble sort)
                        double[] numerosOrdenados = new double[quantidade];
                        for (int i = 0; i < quantidade; i++)
                        {
                            numerosOrdenados[i] = numeros[i];
                        }
                        for (int i = 0; i < quantidade - 1; i++)
                        {
                            for (int j = 0; j < quantidade - 1 - i; j++)
                            {
                                if (numerosOrdenados[j] > numerosOrdenados[j + 1])
                                {
                                    double temp = numerosOrdenados[j];
                                    numerosOrdenados[j] = numerosOrdenados[j + 1];
                                    numerosOrdenados[j + 1] = temp;
                                }
                            }
                        }

                        // Cálculo da mediana
                        double mediana;
                        if (quantidade % 2 == 0)
                        {
                            mediana = (numerosOrdenados[quantidade / 2 - 1] + numerosOrdenados[quantidade / 2]) / 2;
                        }
                        else
                        {
                            mediana = numerosOrdenados[quantidade / 2];
                        }

                        // Cálculo da moda
                        double moda = numerosOrdenados[0];
                        int contagemAtual = 1;
                        int maiorContagem = 1;
                        double numeroAtual = numerosOrdenados[0];

                        for (int i = 1; i < quantidade; i++)
                        {
                            if (numerosOrdenados[i] == numeroAtual)
                            {
                                contagemAtual++;
                                if (contagemAtual > maiorContagem)
                                {
                                    maiorContagem = contagemAtual;
                                    moda = numeroAtual;
                                }
                            }
                            else
                            {
                                numeroAtual = numerosOrdenados[i];
                                contagemAtual = 1;
                            }
                        }

                        // Cálculo do desvio padrão
                        double somaDiferencasQuadrado = 0;
                        for (int i = 0; i < quantidade; i++)
                        {
                            somaDiferencasQuadrado += Math.Pow(numeros[i] - media, 2);
                        }
                        double desvioPadrao = Math.Sqrt(somaDiferencasQuadrado / quantidade);

                        // Exibição dos resultados
                        Console.WriteLine("\n=== Resultados ===");
                        Console.WriteLine($"Média: {media:F2}");
                        Console.WriteLine($"Mediana: {mediana:F2}");
                        Console.WriteLine($"Moda: {moda:F2}");
                        Console.WriteLine($"Desvio Padrão: {desvioPadrao:F2}");
                        Console.WriteLine($"Valor Máximo: {maximo:F2}");
                        Console.WriteLine($"Valor Mínimo: {minimo:F2}");
                        Console.WriteLine($"Amplitude: {(maximo - minimo):F2}");
                        break;

                    case 4:
                        // Limpa os dados
                        quantidade = 0;
                        Console.WriteLine("\nDados limpos com sucesso!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida! Opções: 0 a 4");
                        Console.ResetColor();
                        break;
                }
            } while (opcao != 5);
        }
    }
}
