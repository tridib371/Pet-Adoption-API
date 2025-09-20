using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class AdoptionService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Adoption, AdoptionDTO>().ReverseMap());
            return new Mapper(config);
        }

        public static AdoptionDTO Create(AdoptionDTO adoption)
        {
            adoption.CreatedAt = DateTime.Now;
            var a = GetMapper().Map<Adoption>(adoption);
            var res = DataAccessFactory.AdoptionData().Create(a);
            return GetMapper().Map<AdoptionDTO>(res);
        }

        public static List<AdoptionDTO> Get()
        {
            return GetMapper().Map<List<AdoptionDTO>>(DataAccessFactory.AdoptionData().Get());
        }

        public static AdoptionDTO Get(int id)
        {
            return GetMapper().Map<AdoptionDTO>(DataAccessFactory.AdoptionData().Get(id));
        }

        public static AdoptionDTO Update(AdoptionDTO adoption)
        {
            adoption.UpdatedAt = DateTime.Now;
            var a = GetMapper().Map<Adoption>(adoption);
            return GetMapper().Map<AdoptionDTO>(DataAccessFactory.AdoptionData().Update(a));
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.AdoptionData().Delete(id);
        }
    }
}
