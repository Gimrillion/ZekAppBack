using Application.API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.API.Services.Interfaces
{
    public interface IJsonUserService
    {
        User ParseUser(JObject credentials);

        string GetPassword(JObject credentials);
    }
}
