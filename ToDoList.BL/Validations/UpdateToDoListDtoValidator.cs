using FluentValidation;
using ToDoList.BL.DTO;

namespace ToDoList.BL.Validations;

public class UpdateToDoListDtoValidator : AbstractValidator<UpdateToDoListDto>
{
    public UpdateToDoListDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}