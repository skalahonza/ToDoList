using FluentValidation;
using ToDoList.BL.DTO;

namespace ToDoList.BL.Validations;

public class AddToDoListItemDtoValidator : AbstractValidator<UpdateToDoListItemDto>
{
    public AddToDoListItemDtoValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
    }
}