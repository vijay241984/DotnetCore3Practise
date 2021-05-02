using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;
        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAppCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.id ==id);
        }

        void ICommanderRepo.CreateCommand(Command cmd)
        {
            if (cmd== null)
            {
                throw new ArgumentNullException(nameof(cmd)); 
            }
            _context.Commands.Add(cmd);
        }

        bool ICommanderRepo.SaveChanges()
        {
          return (_context.SaveChanges() >=0 );
        }

        void ICommanderRepo.UpdateCommand(Command cmd)
        {
            ///Nothing
        }
        void ICommanderRepo.DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }
    }
}
