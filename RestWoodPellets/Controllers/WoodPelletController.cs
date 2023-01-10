using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWoodPellets.Manager;
using WoodPelletsLib;

namespace RestWoodPellets.Controllers
{
    [EnableCors("AllowAll")]
    [Route("[controller]")]
    [ApiController]
    public class WoodPelletController : ControllerBase
    {
        private WoodPelletManager _manager = new WoodPelletManager();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<WoodPellet>> Get()
        {
            IEnumerable<WoodPellet> list = _manager.GetAll();
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<WoodPellet> Get(int id)
        {
            WoodPellet foundWoodPellet = _manager.GetById(id);
            if (foundWoodPellet == null)
            {
                return NotFound("No WoodPellet found with that Id! " + id);
            }
            else
            {
                return Ok(foundWoodPellet);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<WoodPellet> Post([FromBody] WoodPellet newWoodPellet)
        {
            try
            {
                WoodPellet createdWoodPellet = _manager.Add(newWoodPellet);
                return Created("/" + createdWoodPellet.Id, createdWoodPellet);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<WoodPellet> Put(int id, [FromBody] WoodPellet updates)
        {
            try
            {
                WoodPellet updatedWoodPellet = _manager.Update(id, updates);
                if (updatedWoodPellet == null)  
                {
                    return NotFound("No WoodPellet found with that Id! " + id);
                }
                return Ok(updatedWoodPellet);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
