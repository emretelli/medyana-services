using Ardalis.GuardClauses;
using Medyana.Services.Api.Hub;
using Medyana.Services.Api.Infrastructure;
using Medyana.Services.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepository<Patient> _repository;
        private readonly IHubContext<PatientHub, IHubClient> _hubContext;
        private readonly ILogger<PatientController> _logger;
        public PatientController(IRepository<Patient> repository, IHubContext<PatientHub, IHubClient> hubContext,
            ILogger<PatientController> logger)
        {
            _repository = repository;
            _hubContext = hubContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Patient> patients = await _repository.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            Patient patient = await _repository.GetAsync(id);
            Guard.Against.Null(patient, nameof(patient));
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            _logger.LogInformation("Insert request {@patient}", patient);
            await _repository.AddAsync(patient);
            await _hubContext.Clients.All.Notify();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Patient patient)
        {
            Patient updatedPatient = await _repository.GetAsync(id);
            Guard.Against.Null(updatedPatient, nameof(updatedPatient));

            _logger.LogInformation("Update request {@patient}", patient);

            _repository.Update(updatedPatient, patient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Patient patient = await _repository.GetAsync(id);
            Guard.Against.Null(patient, nameof(patient));

            _logger.LogInformation("Delete request {@patient}", patient);

            _repository.Delete(patient);
            return Ok();
        }
    }
}
