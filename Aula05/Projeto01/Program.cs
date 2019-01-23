using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto01.Entities;
using Projeto01.Repositories;

namespace Projeto01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nPRODUTOS\n");
            Console.WriteLine("\nEscolha uma das opções a seguir:\n");
            Console.WriteLine("1 - Cadastrar um produto");
            Console.WriteLine("2 - Atualizar um produto");
            Console.WriteLine("3 - Excluir um produto");
            Console.WriteLine("4 - Consultar produtos");
            int opcao = int.Parse(Console.ReadLine());

            Produto produto = new Produto();
            ProdutoRepository repository = new ProdutoRepository();

            switch (opcao)
            {
                #region Caso1
                case 1:
                    try
                    {
                        Console.WriteLine("Nome do Produto....: ");
                        produto.Nome = Console.ReadLine();

                        Console.WriteLine("Preço do Produto...: ");
                        produto.Preco = decimal.Parse(Console.ReadLine());

                        repository.AbrirConexao();
                        repository.Inserir(produto);

                        Console.WriteLine("\nProduto cadastrado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nErro: " + e.Message);
                    }
                    finally
                    {
                        repository.FecharConexao();
                    }
                    break;
                #endregion

                #region Caso2
                case 2:
                    try
                    {
                        Console.WriteLine("Informe o id do Produto que deseja atualizar: ");
                        produto.IdProduto = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nInforme os novos dados do Produto:\n");
                        Console.WriteLine("Nome do Produto....: ");
                        produto.Nome = Console.ReadLine();

                        Console.WriteLine("Preço do Produto...: ");
                        produto.Preco = decimal.Parse(Console.ReadLine());

                        repository.AbrirConexao();
                        repository.Atualizar(produto);

                        Console.WriteLine("\nProduto atualizado com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nErro: " + e.Message);
                    }
                    finally
                    {
                        repository.FecharConexao();
                    }
                    break;
                #endregion
                
                #region Caso3
                case 3:
                    try
                    {
                        Console.WriteLine("Informe o id do Produto que deseja excluir....: ");
                        int idProduto = int.Parse(Console.ReadLine());

                        repository.AbrirConexao();
                        repository.Excluir(idProduto);

                        Console.WriteLine("\nProduto exluído com sucesso!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nErro: " + e.Message);
                    }
                    finally
                    {
                        repository.FecharConexao();
                    }
                    break;
                #endregion

                #region Caso4
                case 4:
                    try
                    {
                        List<Produto> lista = new List<Produto>();

                        repository.AbrirConexao();
                        lista = repository.Consultar();

                        foreach(Produto p in lista)
                        {
                            Console.WriteLine("\nLista de Produtos:\n");
                            Console.WriteLine("IdProduto.........: " + p.IdProduto);
                            Console.WriteLine("Nome..............: " + p.Nome);
                            Console.WriteLine("Preço.............: " + p.Preco);
                            Console.WriteLine("Data de Cadastro..: " + p.DataCadastro);
                            Console.WriteLine("--------------------------------------");
                        }
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nErro: " + e.Message);
                    }
                    finally
                    {
                        repository.FecharConexao();
                    }
                    break;
                #endregion
                default:
                    Console.WriteLine("Escolha uma opção válida!");
                    break;
            }

            Console.ReadKey();
        }
    }
}
