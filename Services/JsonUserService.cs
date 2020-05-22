using Application.API.Models;
using Application.API.Services.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.API.Services
{
    public class JsonUserService : IJsonUserService
    {
        public User ParseUser(JObject credentials)
        {
            string userName = credentials.GetValue(nameof(User.UserName), StringComparison.OrdinalIgnoreCase)
                .ToString();
            if (userName != null)
            {
                return new User() { UserName = userName };
            }
            throw new NullReferenceException();
        }
        public string GetPassword(JObject credentials)
        {
            string password = credentials.GetValue("Password", StringComparison.OrdinalIgnoreCase)
                .ToString();
            if (password != null)
            {
                return password;
            }
            throw new NullReferenceException();
        }
    }

}

