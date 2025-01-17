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
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_repo.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_repo.GetUserById(id));
        }  
        [HttpGet("firebase/{uid}")]
        public IActionResult GetUserByFirebaseUid(string uid)
        {
            return Ok(_repo.GetUserByFirebaseUid(uid));
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _repo.CreateUser(user);
            return Created($"api/Users/{user.Id}", user);
        }
    }
}
