using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ShelterService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Shelter, ShelterDTO>().ReverseMap());
            return new Mapper(config);
        }

        public static ShelterDTO Create(ShelterDTO shelter)
        {
            shelter.CreatedAt = DateTime.Now;
            var s = GetMapper().Map<Shelter>(shelter);
            var res = DataAccessFactory.ShelterData().Create(s);
            return GetMapper().Map<ShelterDTO>(s);

        }

        public static List<ShelterDTO> Get()
        {
            return GetMapper().Map<List<ShelterDTO>>(DataAccessFactory.ShelterData().Get());
        }

        public static ShelterDTO Get(int id)
        {
            return GetMapper().Map<ShelterDTO>(DataAccessFactory.ShelterData().Get(id));
        }


        public static bool Delete(int id)
        {
            return DataAccessFactory.ShelterData().Delete(id);
        }

        public static ShelterDTO Update(ShelterDTO shelter)
        {
            shelter.UpdatedAt = DateTime.Now;
            var s = GetMapper().Map<Shelter>(shelter);
            return GetMapper().Map<ShelterDTO>(DataAccessFactory.ShelterData().Update(s));
        }



    }
}
