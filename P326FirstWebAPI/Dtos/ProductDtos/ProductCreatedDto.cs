using FluentValidation;

namespace P326FirstWebAPI.Dtos.ProductDtos
{
    public class ProductCreatedDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }

    public class ProductCreateDtoValidator:AbstractValidator<ProductCreatedDto>
    {
       public ProductCreateDtoValidator()
        {
            RuleFor(p=>p.CategoryId).NotNull().WithMessage("bosh ola bilmez").GreaterThanOrEqualTo(1);
          RuleFor(p => p.Name).MaximumLength(50).WithMessage("50 den boyuk ola bilmez")
                .NotNull().WithMessage("bos ola bilmez");
            RuleFor(p => p.SalePrice).GreaterThanOrEqualTo(0).WithMessage("0 dan boyuk olmalidir.");
            RuleFor(p => p.CostPrice).GreaterThanOrEqualTo(0).WithMessage("0 dan boyuk olmalidir");
            RuleFor(p  => p.IsActive).Equal(true).WithMessage("true olmalidir...")
                .NotNull().WithMessage("bosh qoymaq olmaz");

            RuleFor(p => p).Custom((p, context) =>
            {
                if (p.SalePrice < p.CostPrice)
                {
                    context.AddFailure("SalePrice", "saleprice costprice-dan kicik ola bilmez");
                }
            });
        }
    }

}
