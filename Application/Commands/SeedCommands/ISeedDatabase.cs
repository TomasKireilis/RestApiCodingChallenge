using System.Threading.Tasks;

namespace Application.Commands.SeedCommands
{
    public interface ISeedDatabaseCommand
    {
        Task Execute();
    }
}