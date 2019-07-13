using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using CmdApi.Models;

namespace CmdApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly CommandContext _context;
/*         public CommandsController(CommandContext context)
        {
            _context = context;
        } */
        
        public CommandsController(CommandContext context) => _context = context;
/* 
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetString()
        {

            return new string[] {"This ","is ","a ","hardcoded ","string."};
        }
 */
        //GET:  api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommands()
        {

            return _context.CommandItems;
        }
                //GET:  api/commands/id
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommand(int id)
        {
            var cmdItem = _context.CommandItems.Find(id);
            if(cmdItem == null)
            {
                return NotFound();
            }
            return cmdItem;
        }

       [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();  // persist to DB
            return CreatedAtAction("GetCommand",new Command{Id=command.Id},command);
        }


        [HttpPut("{id}")]
        public ActionResult PutCommand(int id, Command cmd)
        {
            var cmdItem = _context.CommandItems.Find(id);
            if(cmdItem == null)
            {
                return NotFound();
            }
            return cmdItem;
        }



    }

}