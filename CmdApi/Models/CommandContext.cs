using Microsoft.EntityFrameworkCore;


namespace CmdApi.Models
{

    public class CommandContext : DbContext
    {
        private DbSet<Command> _CommandItems;
        public CommandContext(DbContextOptions<CommandContext> options) :base (options)
        {

        }

        public DbSet<Command> CommandItems { get => _CommandItems; set => _CommandItems = value; }
    }



}