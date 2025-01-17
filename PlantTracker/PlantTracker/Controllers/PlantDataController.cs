﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantTracker.Data;
using PlantTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantTracker.Controllers
{
    [Route("api/Plants")]
    [ApiController]
    public class PlantDataController : ControllerBase
    {
        PlantDataRepository _repo;

        public PlantDataController(PlantDataRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllPlants()
        {
            return Ok(_repo.GetAllPlants());
        }

        [HttpGet("{id}")]
        public IActionResult GetPlantById(int id)
        {
            return Ok(_repo.GetPlantById(id));
        }

        [HttpGet("user/{UserId}")]
        public IActionResult GetPlantsByUserId(int UserId)
        {
            return Ok(_repo.GetAllPlantsForSingleUser(UserId));
        }

        [HttpGet("search/{term}")]
        public IActionResult Search(string term)
        {
            var results = _repo.Search(term);
            return Ok(results);
        }
        [HttpPost]
        public IActionResult AddCustomPlant(PlantData plant)
        {
            _repo.AddCustomPlant(plant);
            return Created($"api/PlantData/{plant.Id}", plant);
        }
        [HttpGet("user/last/{userId}")]
        public IActionResult GetMostRecentCustomPlant(int userId)
        {
            return Ok(_repo.GetMostRecentCustomPlant(userId));
        }
    } 
}
