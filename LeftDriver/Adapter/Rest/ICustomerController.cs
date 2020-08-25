namespace LeftDriver.Adapter.Rest
{
    public interface ICustomerController
    {
        void List();
        void Register();
        void Upgrade();
        void Downgrade();
        void Info();
    }
}