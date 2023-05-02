using Entities.DTOs;
using FluentValidation;

namespace Entities.Validators.FluentValidation
{
    public class CreateProductValidator : AbstractValidator<ProductDtoForInsertion>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .WithMessage("Lütfen ürün adını boş bırakmayınız.");
            RuleFor(p => p.ProductName)
                .MinimumLength(2)
                .WithMessage("Ürün adını en az 2 karakter girmelisiniz."); 
            RuleFor(p => p.Price)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Ürün fiyatı 0 veya 0'dan küçük olamaz.");
            RuleFor(p => p.Stock)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Ürün stok adedi 0'dan küçük olamaz.");
            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .WithMessage("Lütfen kategori alanını boş bırakmayınız.");
        }
    }
}
