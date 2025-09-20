using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class FavoriteService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Favorite, FavoriteDTO>().ReverseMap());
            return new Mapper(config);
        }

        public static FavoriteDTO Create(FavoriteDTO favorite)
        {
            favorite.CreatedAt = DateTime.Now;
            var f = GetMapper().Map<Favorite>(favorite);
            var res = DataAccessFactory.FavoriteData().Create(f);
            if (res) return GetMapper().Map<FavoriteDTO>(f);
            return null;
        }

        public static List<FavoriteDTO> Get()
        {
            return GetMapper().Map<List<FavoriteDTO>>(DataAccessFactory.FavoriteData().Get());
        }

        public static FavoriteDTO Get(int id)
        {
            return GetMapper().Map<FavoriteDTO>(DataAccessFactory.FavoriteData().Get(id));
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.FavoriteData().Delete(id);
        }
    }
}
