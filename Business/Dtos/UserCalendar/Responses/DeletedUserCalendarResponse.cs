﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserCalendar.Responses
{
    public class DeletedUserCalendarResponse
    {
        public Guid UserId { get; set; }
        public Guid CalendarId { get; set; }
    }
}