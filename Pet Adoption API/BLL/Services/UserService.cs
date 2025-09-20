using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static UserDTO Create(UserDTO user)
        {
            user.CreatedAt = DateTime.Now;

            var u = GetMapper().Map<User>(user);
            var res = DataAccessFactory.UserData().Create(u);
            var resM = GetMapper().Map<UserDTO>(res);

            return resM;
        }

        public static List<UserDTO> Get()
        {
            return GetMapper().Map<List<UserDTO>>(DataAccessFactory.UserData().Get());
        }

        public static UserDTO Get(int id)
        {
            return GetMapper().Map<UserDTO>(DataAccessFactory.UserData().Get(id));
        }

        public static UserDTO Update(UserDTO user)
        {
            user.UpdatedAt = DateTime.Now;
            var u = GetMapper().Map<User>(user);
            return GetMapper().Map <UserDTO>(DataAccessFactory.UserData().Update(u));
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }


        public static UserDTO Patch(int id, UserDTO user)
        {
            var u = GetMapper().Map<User>(user);
            var patched = DataAccessFactory.UserPatchData().Patch(id, u);
            return patched != null ? GetMapper().Map<UserDTO>(patched) : null;
        }


    }
}
