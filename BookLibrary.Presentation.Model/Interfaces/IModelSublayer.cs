namespace BookLibrary.Presentation.Model.Interfaces
{
    public interface IModelSublayer
    {
        IEnumerable<IModelUser> GetAllUsers();
        void AddUser(string dni, string name);
    }
}
