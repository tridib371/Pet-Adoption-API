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
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Adoption, AdoptionDTO>().ReverseMap()
            );
            return new Mapper(config);
        }

        public static AdoptionDTO Create(AdoptionDTO adoption)
        {
            adoption.RequestDate = DateTime.Now;
            var a = GetMapper().Map<Adoption>(adoption);
            var res = DataAccessFactory.AdoptionData().Create(a);
            if (res) return GetMapper().Map<AdoptionDTO>(a);
            return null;
        }

        public static List<AdoptionDTO> Get()
        {
            return GetMapper().Map<List<AdoptionDTO>>(DataAccessFactory.AdoptionData().Get());
        }

        public static AdoptionDTO Get(int id)
        {
            return GetMapper().Map<AdoptionDTO>(DataAccessFactory.AdoptionData().Get(id));
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.AdoptionData().Delete(id);
        }

        // ---------------- Workflow Automation ----------------
        public static AdoptionDTO UpdateStatus(int adoptionId, string newStatus)
        {
            var adoption = DataAccessFactory.AdoptionData().Get(adoptionId);
            if (adoption == null) return null;

            adoption.Status = newStatus;
            adoption.DecisionDate = DateTime.Now;

            // Trigger: If Approved, mark pet as adopted
            if (newStatus == "Approved")
            {
                var pet = DataAccessFactory.PetData().Get(adoption.PetId);
                if (pet != null)
                {
                    pet.IsAdopted = true;
                    DataAccessFactory.PetData().Update(pet);
                }
            }

            var res = DataAccessFactory.AdoptionData().Update(adoption);
            if (res) return GetMapper().Map<AdoptionDTO>(adoption);

            return null;
        }
    }
}
    
