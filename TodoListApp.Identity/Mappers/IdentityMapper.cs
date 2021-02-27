using AutoMapper;
using TodoListApp.Entities;
using TodoListApp.Identity.Identities;

namespace TodoListApp.Identity.Mappers
{
    public static class IdentityMapper
    {
        static IdentityMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TodoListAppIdentityUser, User>();
                cfg.CreateMap<User, TodoListAppIdentityUser>();
            });
        }

        public static P Map<T, P>(T source)
        {
            return Mapper.Map<T, P>(source);
        }
    }
}
