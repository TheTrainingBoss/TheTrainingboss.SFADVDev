using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Services.Events;

namespace TheTrainingboss.SFADVDev.Mvc.Models
{
    public interface IRajaEvent: IEvent
    {
        string MyCustomMessage { get; set; }
    }
}