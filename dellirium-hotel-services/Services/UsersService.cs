using dellirium_hotel_data.Context;
using dellirium_hotel_data.Entities;
using dellirium_hotel_services.Models;
using dellirium_hotel_services.Services.Interfaces;
using dellirium_hotel_services.Utils;
using Microsoft.AspNetCore.Mvc;

namespace dellirium_hotel_services.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _appDbContext;
        public UsersService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Create(UserModel user)
        {
            try
            {
                //var userEntity = _mapper.Map<animal_store_data.Entities.User>(user);
                var userEntity = Mapping.Mapper.Map<Users>(user);
                var result = _appDbContext.Users.Add(userEntity);
                _appDbContext.SaveChanges();
                return new ContentResult() { Content = "Exito", StatusCode = 200 };
            }
            catch (Exception e)
            {

                throw new Exception("error al crear: " + e.Message);
            }

        }
    }
}
