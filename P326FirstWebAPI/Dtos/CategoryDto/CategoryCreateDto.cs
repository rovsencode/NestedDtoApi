﻿using FluentValidation;

namespace P326FirstWebAPI.Dtos.CategoryDto
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Photo { get; set; } 

    }


    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(50).WithMessage("50 den boyuk ola bilmez")
                .NotNull().WithMessage("Bos qoyula bilmez");

            RuleFor(p => p.Description)
                .MaximumLength(50).WithMessage("50 den boyuk ola bilmez")
                .NotNull().WithMessage("Bos qoyula bilmez");


        }
    }
}
