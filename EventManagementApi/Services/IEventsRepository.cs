﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services
{
   public interface IEventsRepository
    {
         Event Add(Event newEvent);

        IEnumerable<Event> GetAll();

        Event GetById(int id);


        void Delete(int id);
    }
}
