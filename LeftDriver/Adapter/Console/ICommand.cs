namespace LeftDriver.Adapter.Console
{
    public interface ICommand
    {
        void List();
        void Register();
        void Upgrade();
        void Downgrade();
        void Info();
    }
}