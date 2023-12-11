using System.Data;

namespace RAZOR_Chat.Interface
{
    public interface IConnectionmanager
    {
        IDbConnection getNewConnection();

    }
}
