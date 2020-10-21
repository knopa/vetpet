namespace VetPet.Repository
{
    public interface IUnitOfWork
    {
        R CreateRepository<R>();
        void Save();
        AnimalRepository AnimalRepository { get; }
        void Dispose();
    }
}