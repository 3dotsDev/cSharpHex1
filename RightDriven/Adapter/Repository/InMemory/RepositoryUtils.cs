using System.Threading;

namespace RightDriven.Adapter.Repository
{
    public class RepositoryUtils
    {
        private static int _primaryKey = 0;

        public static int GetPrimaryKey()
        {
            return Interlocked.Increment(ref _primaryKey);
        }
    }
}