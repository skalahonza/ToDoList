using FluentValidation;
using ToDoList.BL.DTO;

namespace ToDoList.BL.Validations;

public class CreateToDoListDtoValidator : AbstractValidator<CreateToDoListDto>
{
    public CreateToDoListDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}