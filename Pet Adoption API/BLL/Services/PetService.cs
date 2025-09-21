using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static List<PetDTO> Search(PetDTO filter)
        {
            var pets = GetMapper().Map<List<PetDTO>>(DataAccessFactory.PetData().Get());

            if (!string.IsNullOrEmpty(filter.Name))
                pets = pets.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower())).ToList();

            if (filter.Age > 0)
                pets = pets.Where(p => p.Age == filter.Age).ToList();

            if (!string.IsNullOrEmpty(filter.Category))
                pets = pets.Where(p => p.Category.ToLower() == filter.Category.ToLower()).ToList();

            if (!string.IsNullOrEmpty(filter.Gender))
                pets = pets.Where(p => p.Gender.ToLower() == filter.Gender.ToLower()).ToList();

            if (!string.IsNullOrEmpty(filter.Breed))
                pets = pets.Where(p => p.Breed.ToLower().Contains(filter.Breed.ToLower())).ToList();

            if (filter.IsAdopted)
                pets = pets.Where(p => p.IsAdopted == filter.IsAdopted).ToList();

            return pets;
        }

    }
}
