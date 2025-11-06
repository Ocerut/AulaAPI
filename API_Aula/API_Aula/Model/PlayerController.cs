using API_Aula.Model;
using Microsoft.AspNetCore.Mvc;

namespace AulaAPI.Controllers
{
    public class PlayerController : ControllerBase
    {
        public static List<Player> players = new List<Player>
        {
            new Player { Id = "1", Vida = "100", QtdeItens = "0", PosX = "0", PosY = "0", PosZ = "0" },
            new Player { Id = "2", Vida = "90", QtdeItens = "0", PosX = "0", PosY = "0", PosZ = "0" }
        }; 
        [HttpGet]
        [Route("api/players")]
        public IActionResult GetPlayers()
        {
            return Ok(players);
        }
        [HttpGet]
        [Route("api/players/{id}")]
        public IActionResult GetPlayer(string id)
        {
            var player = players.FirstOrDefault(a => a.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }
        [HttpPost]
        [Route("api/players")]
        public IActionResult AddPlayer([FromBody] Player novoPlayer)
        {
            players.Add(novoPlayer);
            return Ok(novoPlayer);
        }

    }

}