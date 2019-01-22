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
            Produto produto = new Produto();
            ProdutoRepository repository = new ProdutoRepository();

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
            catch(Exception e)
            {
                Console.WriteLine("\nErro: " + e.Message);
            }
            finally
            {
                repository.FecharConexao();
            }



        }
    }
}
