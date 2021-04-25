using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Medyana.Services.XmlConsumerConsoleApp
{
    public class PatientManager
    {
        private readonly HttpClient client = new HttpClient();
        public PatientManager()
        {
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        

        public async Task SendPatientListToApi(List<PatientEntity> patientEntities)
        {
            Guard.Against.Null(patientEntities, nameof(patientEntities));
            for(int i = 0; i<patientEntities.Count; i++)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/patient", patientEntities[i]);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
