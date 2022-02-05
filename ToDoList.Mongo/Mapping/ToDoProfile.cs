using AutoMapper;
using ToDoList.BL.DTO;
using ToDoList.Mongo.Entities;

namespace ToDoList.Mongo.Mapping;

public class ToDoProfile : Profile
{
    public ToDoProfile()
    {
        CreateMap<ToDoListEntity, ToDoListInfoDto>();
        CreateMap<ToDoListEntity, ToDoListDetailDto>();
        CreateMap<ToDoItemEntity, ToDoListItemDto>();
    }
}