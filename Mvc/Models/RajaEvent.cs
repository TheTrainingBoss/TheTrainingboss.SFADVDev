using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheTrainingboss.SFADVDev.Mvc.Models
{
    public class RajaEvent : IRajaEvent
    {
        public string MyCustomMessage { get; set; }
        public string Origin { get; set; }
    }
}