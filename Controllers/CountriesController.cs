﻿using CountryFilterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CountryFilterAPI.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountriesController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CountriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        [Route("/{mainland}")]
        public async Task<IActionResult> GetAsianCountries(string mainland)
        {
            var response = await _httpClient.GetAsync("https://restcountries.com/v2/all");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to fetch countries");
            }

            var content = await response.Content.ReadAsStringAsync();
            var countries = JsonSerializer.Deserialize<List<Country>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            var result = countries?.Where(c => c.Region == mainland).ToList();

            return Ok(result);
        }
    }
}