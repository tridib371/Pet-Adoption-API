using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ReportService
    {
        public static ReportDTO GenerateReport()
        {
            var report = new ReportDTO();

            // Pets by category
            var pets = DataAccessFactory.PetData().Get();
            report.PetsByCategory = pets
                .GroupBy(p => p.Category)
                .ToDictionary(g => g.Key, g => g.Count());

            // Adoptions by status
            var adoptions = DataAccessFactory.AdoptionData().Get();
            report.AdoptionsByStatus = adoptions
                .GroupBy(a => a.Status)
                .ToDictionary(g => g.Key, g => g.Count());

            // Pets by Shelter
            var shelters = DataAccessFactory.ShelterData().Get();
            report.PetsByShelter = pets
                .GroupBy(p => p.ShelterId)
                .ToDictionary(
                    g => shelters.FirstOrDefault(s => s.ShelterId == g.Key)?.Name ?? "Unknown Shelter",
                    g => g.Count()
                );

            return report;
        }
    }
}
