namespace Autofixture.Tutorial
{
    public interface IContactsRepository
    {
        Contact[] ListContaining(string text);
    }
}