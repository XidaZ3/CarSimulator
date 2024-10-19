using CarSimulator.DTOs;
using CarSimulator.DTOs.Cars.Bodies;
using CarSimulator.DTOs.Cars.Requests;
using CarSimulator.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CarSimulator.Controllers
{
    // TODO: Should find a way to avoid wrapping every request in a try-catch block

    [Route("api/cars")]
    [ApiController] // Ensures this is treated as an API controller
    public class CarsController : BaseController
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar()
        {
            try
            {
                var car = new Car();

                if (!ModelState.IsValid || !car.IsNumberOfWheelsValid())
                {

                    var errors = new List<string>();

                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }

                    if (!car.IsNumberOfWheelsValid())
                    {
                        errors.Add($"A car must have exactly {Car.ValidNumberOfWheelsNeeded()} wheels.");
                    }

                    return UnprocessableEntity(new { Errors = errors });
                }

                _context.Cars.Add(car);
                await _context.SaveChangesAsync();

                var resultDto = new CarDto
                {
                    Id = car.Id,
                    Type = car.Type,
                    Body = new BodyDto
                    {
                        Id = car.Body.Id,
                        SelectedAlertType = car.Body.SelectedAlertType,
                        Tank = new TankDto
                        {
                            Id = car.Body.Tank.Id,
                            FuelType = car.Body.Tank.FuelType,
                            FuelAmount = car.Body.Tank.FuelAmount
                        }
                    }
                };

                return CreatedAtAction(nameof(GetCar), new { id = resultDto.Id }, resultDto);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            try
            {
                var car = await _context.Cars
                                .Include(c => c.Body)
                                .ThenInclude(b => b.Tank)
                                .FirstOrDefaultAsync(c => c.Id == id);

                if (car == null)
                {
                    return NotFound();
                }

                var resultDto = new CarDto
                {
                    Id = car.Id,
                    Type = car.Type,
                    Body = new BodyDto
                    {
                        Id = car.Body.Id,
                        SelectedAlertType = car.Body.SelectedAlertType,
                        Tank = new TankDto
                        {
                            Id = car.Body.Tank.Id,
                            FuelType = car.Body.Tank.FuelType,
                            FuelAmount = car.Body.Tank.FuelAmount
                        }
                    }
                };
                return Ok(resultDto);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }

        }

        [HttpGet("{id}/get-type")]
        public async Task<ActionResult<Car>> GetType(int id)
        {
            try
            {
                var car = await _context.Cars.FindAsync(id);

                if (car == null)
                {
                    return NotFound();
                }

                return Ok(new { type = car.Type.ToString() });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }

        }

        [HttpPatch("{id}/accelerate")]
        public async Task<ActionResult<Car>> Accelerate(int id)
        {
            try
            {
                var car = await _context.Cars
                               .Include(c => c.Body)
                               .ThenInclude(b => b.Accelerator)
                               .Include(c => c.Body.Tank)
                               .Include(c => c.Body.Engine)
                               .FirstOrDefaultAsync(c => c.Id == id);

                if (car == null)
                {
                    return NotFound();
                }

                car.Body.Accelerator.Push();

                await _context.SaveChangesAsync();

                return Ok(new { speed = car.Speed });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPatch("{id}/brake")]
        public async Task<ActionResult<Car>> Brake(int id)
        {
            try
            {
                var car = await _context.Cars
                                .Include(c => c.Body)
                                   .ThenInclude(b => b.Brake)
                                   .FirstOrDefaultAsync(c => c.Id == id);


                if (car == null)
                {
                    return NotFound();
                }

                car.Body.Brake.Push();

                await _context.SaveChangesAsync();

                return Ok(new { speed = car.Speed });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPatch("{id}/steer")]
        public async Task<ActionResult<Car>> Steer(int id, [FromBody] SteerRequestDto steerRequest)
        {
            try
            {

                var car = await _context.Cars
                                .Include(c => c.Body)
                                .ThenInclude(b => b.SteeringWheel)
                                .FirstOrDefaultAsync(c => c.Id == id);


                if (car == null)
                {
                    return NotFound();
                }

                car.Body.SteeringWheel.Steer(steerRequest.Degrees);

                await _context.SaveChangesAsync();

                return Ok(new { direction = car.Direction });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet("{id}/get-speed")]
        public async Task<ActionResult<Car>> GetSpeed(int id)
        {
            try
            {
                var car = await _context.Cars.FindAsync(id);

                if (car == null)
                {
                    return NotFound();
                }

                return Ok(new { speed = car.Speed });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet("{id}/get-direction")]
        public async Task<ActionResult<Car>> GetDirection(int id)
        {
            try
            {
                var car = await _context.Cars.FindAsync(id);

                if (car == null)
                {
                    return NotFound();
                }

                return Ok(new { direction = car.Direction });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPatch("{id}/fill-with")]
        public async Task<ActionResult<Car>> fillWith(int id, [FromBody] FillTankRequestDto fillTankRequestDto)
        {
            try
            {
                var car = await _context.Cars
                               .Include(c => c.Body)
                               .ThenInclude(b => b.Tank)
                               .FirstOrDefaultAsync(c => c.Id == id);

                if (car == null)
                {
                    return NotFound();
                }

                car.Body.Tank.RefillFuel(fillTankRequestDto.fuelType);

                await _context.SaveChangesAsync();

                var resultDto = new CarDto
                {
                    Id = car.Id,
                    Type = car.Type,
                    Body = new BodyDto
                    {
                        Id = car.Body.Id,
                        SelectedAlertType = car.Body.SelectedAlertType,
                        Tank = new TankDto
                        {
                            FuelType = car.Body.Tank.FuelType,
                            FuelAmount = car.Body.Tank.FuelAmount
                        }
                    }
                };
                return Ok(resultDto);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpGet("{id}/honk")]
        public async Task<ActionResult<Car>> GetHonk(int id)
        {
            try
            {
                var car = await _context.Cars
                          .Include(c => c.Body)
                          .FirstOrDefaultAsync(c => c.Id == id);

                if (car == null)
                {
                    return NotFound();
                }

                return Ok(new { honk = car.Body.Honk() });
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }
    }
}
