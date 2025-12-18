using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAllAddressQueryHandler  getAllAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler   getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler removeAddressCommandHandler;



        public AddressesController(GetAllAddressQueryHandler getAllAddressQueryHandler,
                                   GetAddressByIdQueryHandler getAddressByIdQueryHandler,
                                   CreateAddressCommandHandler createAddressCommandHandler,
                                   UpdateAddressCommandHandler updateAddressCommandHandler,
                                   RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            this.getAllAddressQueryHandler = getAllAddressQueryHandler;
            this.getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            this.createAddressCommandHandler = createAddressCommandHandler;
            this.updateAddressCommandHandler = updateAddressCommandHandler;
            this.removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await getAllAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var value = await getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);   
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await createAddressCommandHandler.Handle(command);
            return Ok("Address successfully added.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await updateAddressCommandHandler.Handle(command);
            return Ok("Address successfully updated.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress( int id)
        {
            await removeAddressCommandHandler.Handle(new RemoveAddressCommand (id));
            return Ok("Address successfully deleted.");
        }
    }
}
