using FluentValidation;
using LivrariaAPI_DIO.Models;

namespace LivrariaAPI_DIO.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O campo deve {PropertyName} precisa ser fornecido")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(p => p.Categoria)
                .NotEmpty().WithMessage("O campo deve {PropertyName} precisa ser fornecido")
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 30).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(p => p.Img)
                .NotEmpty().WithMessage("É necessário fornecer um endereço de imagem")
                .NotNull().WithMessage("É necessário fornecer um endereço de imagem")
                .Length(10, 200);
            RuleFor(p => p.Quantidade)
                .NotNull().WithMessage("Informe a quantidade do produto")
                .NotEmpty().WithMessage("Informe a quantidade do produto")
                .GreaterThan(0).WithMessage("Inválido! Cadastre apenas valores maiores que 0");
            RuleFor(p => p.Preco)
                .NotEmpty().WithMessage("É necessário informar o preço do produto!")
                .NotNull().WithMessage("É necessário informar o preço do produto!")
                .GreaterThan(0).WithMessage("Inválido! Cadastre apenas valores maiores que 0");
        }
    }
}
