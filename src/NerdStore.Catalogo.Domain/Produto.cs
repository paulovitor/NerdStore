using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public const string NomeVazio = "O campo Nome do produto não pode estar vazio";
        public const string DescricaoVazia = "O campo Descrição do produto não pode estar vazio";
        public const string CategoriaIdVazio = "O campo CategoriaId do produto não pode estar vazio";
        public const string ValorMenorOuIgualAZero = "O campo Valor do produto não pode se menor ou igual a 0";
        public const string ImagemVazia = "O campo Imagem do produto não pode estar vazio";

        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;

            Validar();
        }

        // ad hoc setters
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, DescricaoVazia);
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, NomeVazio);
            Validacoes.ValidarSeVazio(Descricao, DescricaoVazia);
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, CategoriaIdVazio);
            Validacoes.ValidarSeMenorQue(Valor, 1, ValorMenorOuIgualAZero);
            Validacoes.ValidarSeVazio(Imagem, ImagemVazia);
        }
    }
}