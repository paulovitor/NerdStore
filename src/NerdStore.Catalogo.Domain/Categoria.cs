using System.Collections.Generic;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public const string NomeVazio = "O campo Nome da categoria não pode estar vazio";
        public const string CodigoIgualAZero = "O campo Código não pode ser 0";

        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; set; }

        protected Categoria()
        {
        }

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, NomeVazio);
            Validacoes.ValidarSeIgual(Codigo, 0, CodigoIgualAZero);
        }
    }
}