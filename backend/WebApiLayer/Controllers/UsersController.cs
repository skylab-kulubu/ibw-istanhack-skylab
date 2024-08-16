﻿using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLayer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet("getAllUsers")]
    public IActionResult GetAllUsers()
    {
        var result = userService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getById/{id}")]
    public IActionResult GetUserById(int id)
    {
        var result = userService.GetById(id);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPost("addUser")]
    public IActionResult AddUser(User user)
    {
        var result = userService.Add(user);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPut("updateUser/{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        user.userId = id;
        var result = userService.Update(user);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpDelete("deleteUser/{id}")]
    public IActionResult DeleteUser(int id)
    {
        var result = userService.Delete(id);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("getUserByEmail/{email}")]
    public IActionResult GetUserByEmail(string email)
    {
        var result = userService.GetUserByEmail(email);

        if (result.Success)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}