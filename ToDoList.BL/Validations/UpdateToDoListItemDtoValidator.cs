using FluentValidation;
using ToDoList.BL.DTO;

namespace ToDoList.BL.Validations;

public class UpdateToDoListItemDtoValidator : AbstractValidator<UpdateToDoListItemDto>
{
    public UpdateToDoListItemDtoValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
    }
}