using System;
using System.Collections.Generic;

namespace Passagens
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PassagemAerea> passagens = new List<PassagemAerea>();
            bool controle = true;
            while (controle)
            {
                Console.WriteLine("Bem vindo ao sistema Passagens!\n\nSelecione o dígito da operação a ser realizada:\n\n1 - Cadastrar passagem;" +
                    "\n2 - Remover passagem;\n3 - Listar todas as passagens;\n4 - Sair.");
                if (Enum.TryParse<Menu>(Console.ReadLine(), true, out Menu menu))
                {
                    switch (menu)
                    {
                        case Menu.Cadastrar:
                            Cadastrar(passagens);
                            break;
                        case Menu.Remover:
                            Remover(passagens);
                            break;
                        case Menu.Listar:
                            Listar(passagens);
                            break;
                        case Menu.Sair:
                            Console.Clear();
                            Console.WriteLine("Obrigado por utilizar nosso sistema de Passagens!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Resposta inválida. |");
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ocorreu um erro. |");
                    Console.WriteLine(new string('-', 18));
                    Console.WriteLine("");
                }
            }
        }
        public static void Cadastrar(List<PassagemAerea> passagens)
        {
            Console.Clear();
            bool loopAdd = true;
            while (loopAdd)
            {
                Console.WriteLine("Digite, linha a linha, o local de origem da viagem, o destino, a data da viagem e seu preço:");
                string origem = Console.ReadLine();
                string destino = Console.ReadLine();
                string dataInput = Console.ReadLine();
                double preco = int.Parse(Console.ReadLine());
                if (!String.IsNullOrWhiteSpace(origem) && !String.IsNullOrWhiteSpace(destino)
                    && DateTime.TryParseExact(dataInput, "ddmmyyyy", null, System.Globalization.DateTimeStyles.None, out DateTime data))
                {
                    Console.Clear();
                    bool loopAdd2 = true;
                    while (loopAdd2)
                    {
                        Console.WriteLine($"A viagem de {origem} para {destino} é de qual classe?\n\n1 - Econômica;\n2 - " +
                            $"Executiva;\n3 - Primeira Classe.");
                        if (Enum.TryParse<TipoPassagem>(Console.ReadLine(), true, out TipoPassagem tipo))
                        {
                            Console.WriteLine("O usuário é frequente ('s'/'n')?");
                            string inputFrequencia = Console.ReadLine();
                            if (inputFrequencia == "s")
                            {
                                PassagemAerea p = tipo switch
                                {
                                    TipoPassagem.Economica => new PassagemEconomica(origem, destino, data, preco, tipo, true),
                                    TipoPassagem.Executiva => new PassagemExecutiva(origem, destino, data, preco, tipo, true),
                                    TipoPassagem.PrimeiraClasse => new PassagemPrimeiraClasse(origem, destino, data, preco, tipo, true),
                                    _ => null
                                };
                                if (p != null)
                                {
                                    passagens.Add(p);
                                    Console.Clear();
                                    Console.WriteLine("Passagem adicionada com sucesso! |");
                                    Console.WriteLine(new string('-', 34));
                                    Console.WriteLine("");
                                    loopAdd = false;
                                    loopAdd2 = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ocorreu um erro. |");
                                    Console.WriteLine(new string('-', 18));
                                    Console.WriteLine("");
                                    loopAdd = false;
                                    loopAdd2 = false;
                                }
                            }
                            else if (inputFrequencia == "n")
                            {
                                PassagemAerea p = tipo switch
                                {
                                    TipoPassagem.Economica => new PassagemEconomica(origem, destino, data, preco, tipo, false),
                                    TipoPassagem.Executiva => new PassagemExecutiva(origem, destino, data, preco, tipo, false),
                                    TipoPassagem.PrimeiraClasse => new PassagemPrimeiraClasse(origem, destino, data, preco, tipo, false),
                                    _ => null
                                };
                                if (p != null)
                                {
                                    passagens.Add(p);
                                    Console.Clear();
                                    Console.WriteLine("Passagem adicionada com sucesso! |");
                                    Console.WriteLine(new string('-', 34));
                                    Console.WriteLine("");
                                    loopAdd = false;
                                    loopAdd2 = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Ocorreu um erro. |");
                                    Console.WriteLine(new string('-', 18));
                                    Console.WriteLine("");
                                    loopAdd = false;
                                    loopAdd2 = false;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ocorreu um erro. |");
                                Console.WriteLine(new string('-', 18));
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Resposta inválida. |");
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("");
                        }
                    }
                }
            }
        }
        public static void Remover(List<PassagemAerea> passagens)
        {
            if (passagens.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há passagens a serem removidas! |");
                Console.WriteLine(new string('-', 37));
                Console.WriteLine("");
                return;
            }
            bool loopRem = true;
            while (loopRem)
            {
                Console.WriteLine("Passagens:\n");
                Console.WriteLine(new string('-', 80));
                for (int i = 0; i < passagens.Count; i++)
                {
                    PassagemAerea p = passagens[i];
                    if (p != null)
                    {
                        Console.WriteLine($"\nPassagem {passagens[i].IDPassagem} do tipo {p.Tipo}, indo de {p.Origem} a {p.Destino} na data" +
                            $" {p.DataViagem} com preço de R${p.CalcularPreco(p.Preco, p.Frequente)};\n");
                    }
                }
                Console.WriteLine("Informe o código do produto a ser removido:");
                int inputID = int.Parse(Console.ReadLine());
                PassagemAerea passagem = passagens.Find(p => p.IDPassagem == inputID);
                if (passagem != null)
                {
                    passagens.Remove(passagem);
                    Console.WriteLine("Passagem removida com sucesso! |");
                    Console.WriteLine(new string('-', 32));
                    Console.WriteLine("");
                    loopRem = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ocorreu um erro. |");
                    Console.WriteLine(new string('-', 18));
                    Console.WriteLine("");
                }
            }
        }
        public static void Listar(List<PassagemAerea> passagens)
        {
            if (passagens.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Nenhuma passagem foi cadastrada! |");
                Console.WriteLine(new string('-', 34));
                Console.WriteLine("");
                return;
            }
            Console.Clear();
            Console.WriteLine("Passagens:\n");
            double precoTotal = 0;
            Console.WriteLine(new string('-', 80));
            for (int i = 0; i < passagens.Count; i++)
            {
                PassagemAerea p = passagens[i];
                if (p != null)
                {
                    double preco = passagens[i].CalcularPreco(passagens[i].Preco, passagens[i].Frequente);
                    precoTotal += preco;
                    Console.WriteLine($"\nPassagem {passagens[i].IDPassagem} do tipo {p.Tipo}, indo de {p.Origem} a {p.Destino} na data " +
                        $"{p.DataViagem} com preço de R${p.CalcularPreco(p.Preco, p.Frequente)};\n");
                    Console.WriteLine(new string('-', 80));
                }
            }
            Console.WriteLine($"Valor total das passagens - R${precoTotal}.");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("");
        }
    }
}