using BigOn.Domain.Business.BrandModule;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BigOn.WebApi.Controllers
{
    [Route("api/[controller]")] //ishletmey uchun slash api slash controller adi
    [ApiController]
    public class BrandsController : ControllerBase //toreyir bunda view redirect yoxdu deye apide lazimdi.
    {
        
        private readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async  Task<IActionResult> Get([FromRoute]BrandGetAllQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]BrandSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }




        [HttpPost]
        public async Task<IActionResult> Create(BrandCreateCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }



        [HttpPut("{id}")] //sene id gelecek
        public async Task<IActionResult> Edit(int id,[FromBody]BrandEditCommand command)//brandi from bodyden gotureceksen
        {
            command.Id = id;
            var response = await mediator.Send(command);
            //where ilede yaza bilerik ama firstorda shert yaza bilerik id e gore 1 dene lazimdi deye to list yazmirig

            if (response == null) //yoxdusa 404 qaytaraq
            {
                return NotFound();
            }

           
            return Ok(response);
        }


        [HttpDelete("{id}")]//rootda gonder ve bu idli elementi silersen
        public async Task<IActionResult> Remove([FromRoute]BrandRemoveCommand command)
        {
            var response = await mediator.Send(command);
            //where ilede yaza bilerik ama firstorda shert yaza bilerik id e gore 1 dene lazimdi deye to list yazmirig

            if (response == null) //yoxdusa 404 qaytaraq
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
