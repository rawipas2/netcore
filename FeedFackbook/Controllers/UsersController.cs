using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using FeedFackbook.Models;
using System.Text.Json;
using FeedFackbook.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeedFackbook.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        UserService _userService;
        public UsersController()
        {
            _userService = new UserService();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //UserViewModel user = new UserViewModel();
            //user.Id = 1;
            //user.Name = "Thong";
            //return new OkObjectResult(user);//"{\"results\":\"test\" }";
            using (StreamReader sr = new StreamReader("Mocking/User.json"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                Console.WriteLine(line);
                return new OkObjectResult(line);
            }

        }

        [HttpGet("Login/{username}/{password}")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var result = _userService.GetUserLogin(username, password);
                if (result != null)
                    return new OkObjectResult(result);
                else
                    return NotFound("Invalid username or password");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //using (StreamReader sr = new StreamReader("Mocking/User.json"))
            //{
            //    // Read the stream to a string, and write the string to the console.
            //    String line = sr.ReadToEnd();
            //    Console.WriteLine(line);

            //    //var json = JsonSerializer.Deserialize(line);
            //    var user = JsonSerializer.Deserialize<UserViewModel>(line);get
            //    if (user.Login.Username.Equals(Username) && user.Login.Password.Equals(Password))
            //    {
            //        return new OkObjectResult(user);
            //    }
            //    else
            //    {
            //        return new NotFoundObjectResult("Invalid Username or password");
            //    }
            //}
        }
        [HttpGet("GetProfile/{UserId}")]
        public IActionResult GetProfile(int userId)
        {
            try
            {
                var result = _userService.GetUserById(userId);
                if (result != null)
                {
                    result.Friends = _userService.GetFriendByUserId(userId, 6);
                    return new OkObjectResult(result);
                }
                else
                {
                    return NotFound("Invalid user");
                }

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllFriends/{UserId}")]
        public IActionResult GetAllFriends(int userId)
        {
            try
            {
                var results = _userService.GetFriendByUserId(userId);
                if (results != null)
                {
                    return new OkObjectResult(results);
                }
                else
                {
                    return NotFound("Friend is empty.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("GetFeeds/{UserId}")]
        public IActionResult GetFeeds(int userId)
        {
            try
            {
                var results = _userService.GetFeedByUserId(userId);
                if (results != null && results.Count > 0)
                    return new OkObjectResult(results);
                else
                    return NotFound("Feed not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
