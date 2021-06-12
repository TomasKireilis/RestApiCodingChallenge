using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ISeedDatabaseCommand
    {
        Task Execute();
    }
}