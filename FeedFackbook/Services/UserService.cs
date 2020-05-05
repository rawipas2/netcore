using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using FeedFackbook.Models;
using System.Text.Json;
using FeedFackbook.Services;

namespace FeedFackbook.Services
{
    public class UserService
    {
        public UserService()
        {
        }
        public UserViewModel GetUserById(int userId)
        {
            UserViewModel result = null;
            using (StreamReader sr = new StreamReader("Mocking/User.json"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                Console.WriteLine(line);

                //var json = JsonSerializer.Deserialize(line);
                var users = JsonSerializer.Deserialize<List<UserViewModel>>(line);
                //if (user.UserId == userId)
                //    result = user;
                result = users.Where(u => u.UserId == userId).FirstOrDefault();
                return result;
            }
        }
        public UserViewModel GetUserLogin(string username, string password)
        {
            UserViewModel result = null;
            using (StreamReader sr = new StreamReader("Mocking/User.json"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                Console.WriteLine(line);

                //var json = JsonSerializer.Deserialize(line);
                var users = JsonSerializer.Deserialize<List<UserViewModel>>(line);
                result = users.Where(u => u.Login.Username.Equals(username) && u.Login.Password.Equals(password)).FirstOrDefault();
                    
                //if (user.Login.Username.Equals(username) && user.Login.Password.Equals(password))
                //{
                //    result = user;
                //}
                return result;
            }
        }
        public List<FriendViewModel> GetFriendByUserId(int userId)
        {
            return GetFriendByUserId(userId, 0);
            
        }

        public List<FriendViewModel> GetFriendByUserId(int userId, int limit)
        {
            List<FriendViewModel> results = null;
            using (StreamReader sr = new StreamReader("Mocking/Friends.json"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                Console.WriteLine(line);

                //var json = JsonSerializer.Deserialize(line);
                var feeds = JsonSerializer.Deserialize<List<FriendViewModel>>(line);
                if (feeds != null && feeds.Count > 0)
                {
                    // select * from friend where parentUser == userId
                    if(limit > 0)
                        results = feeds.Where(f => f.ParentUserId == userId).Select(f => f).Take(limit).ToList();
                    else
                        results = feeds.Where(f => f.ParentUserId == userId).Select(f => f).ToList();
                }
                return results;
            }
        }

        public List<FeedViewModel> GetFeedByUserId(int userId)
        {
            List<FeedViewModel> results = null;
            using (StreamReader sr = new StreamReader("Mocking/Feed.json"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                Console.WriteLine(line);

                //var json = JsonSerializer.Deserialize(line);
                var feeds = JsonSerializer.Deserialize<List<FeedViewModel>>(line);
                if (feeds != null && feeds.Count > 0)
                {
                    // select * from friend where parentUser == userId
                    results = feeds.Where(f => f.ParentUserId == userId).Select(f => f).ToList();
                }
                return results;
            }
        }
    }
}
