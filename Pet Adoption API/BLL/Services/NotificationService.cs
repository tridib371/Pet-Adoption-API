using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class NotificationService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Notification, NotificationDTO>().ReverseMap());
            return new Mapper(config);
        }

        public static NotificationDTO Create(NotificationDTO notif)
        {
            notif.CreatedAt = DateTime.Now;
            var n = GetMapper().Map<Notification>(notif);
            var res = DataAccessFactory.NotificationData().Create(n);
            if (res) return GetMapper().Map<NotificationDTO>(n);
            return null;
        }

        public static List<NotificationDTO> GetAll()
        {
            return GetMapper().Map<List<NotificationDTO>>(DataAccessFactory.NotificationData().Get());
        }

        public static bool MarkAsRead(int id)
        {
            var n = DataAccessFactory.NotificationData().Get(id);
            if (n == null) return false;
            n.IsRead = true;
            return DataAccessFactory.NotificationData().Update(n);
        }
    }
}
