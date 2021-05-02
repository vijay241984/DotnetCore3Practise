using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var Commands = new List<Command>
            {
              new Command { id = 0, HowTo = "Tea", Line = "Tea Powder", Platform = "Tea Machine" },
              new Command { id = 1, HowTo = "Cofee", Line = "Cofee Powder", Platform = "Coffe Machine" },
              new Command { id = 2, HowTo = "BoiledEgg", Line = "Egg", Platform = "Pan" }
            };

            return Commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { id = 0, HowTo = "Tea", Line = "Tea Powder", Platform = "Tea Machine" };
        }

        void ICommanderRepo.CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        void ICommanderRepo.DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        bool ICommanderRepo.SaveChanges()
        {
            throw new NotImplementedException();
        }

        void ICommanderRepo.UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
