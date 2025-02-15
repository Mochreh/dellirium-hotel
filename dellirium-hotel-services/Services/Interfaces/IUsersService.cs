using dellirium_hotel_services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dellirium_hotel_services.Services.Interfaces
{
    public interface IUsersService
    {
        IActionResult Create(UserModel user);

    }
}
