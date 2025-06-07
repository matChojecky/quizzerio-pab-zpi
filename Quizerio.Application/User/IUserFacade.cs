namespace Application.User
{
    public interface IUserFacade
    {
        void CreateUser();

        void UpdateUser();

        void DeleteUser(Guid userId);
    }
}