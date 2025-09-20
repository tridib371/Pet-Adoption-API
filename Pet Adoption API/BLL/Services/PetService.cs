using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class PetService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Pet, PetDTO>().ReverseMap());
            return new Mapper(config);
        }

        public static PetDTO Create(PetDTO pet)
        {
            pet.CreatedAt = DateTime.Now;
            var p = GetMapper().Map<Pet>(pet);
            var res = DataAccessFactory.PetData().Create(p);
            if(res) return GetMapper().Map<PetDTO>(p);
            return null;
        }

        public static List<PetDTO> Get()
        {
            return GetMapper().Map<List<PetDTO>>(DataAccessFactory.PetData().Get());
        }

        public static PetDTO Get(int id)
        {
            return GetMapper().Map<PetDTO>(DataAccessFactory.PetData().Get(id));
        }

        public static PetDTO Update(PetDTO pet)
        {
            pet.UpdatedAt = DateTime.Now;
            var p = GetMapper().Map<Pet>(pet);
            var res = DataAccessFactory.PetData().Update(p);
            if (res)return GetMapper().Map<PetDTO>(p);
            return null;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PetData().Delete(id);
        }
    }
}
