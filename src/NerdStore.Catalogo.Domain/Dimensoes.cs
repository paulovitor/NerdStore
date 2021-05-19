using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    // Value Object
    public class Dimensoes
    {
        public const string AlturaMenorOuIgualAZero = "O campo Altura não pode ser menor ou igual a 0";
        public const string LarguraMenorOuIgualAZero = "O campo Largura não pode ser menor ou igual a 0";
        public const string ProfundidadeMenorOuIgualAZero = "O campo Profundidade não pode ser menor ou igual a 0";

        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;

            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarSeMenorQue(Altura, 1, AlturaMenorOuIgualAZero);
            Validacoes.ValidarSeMenorQue(Largura, 1, LarguraMenorOuIgualAZero);
            Validacoes.ValidarSeMenorQue(Profundidade, 1, ProfundidadeMenorOuIgualAZero);
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}