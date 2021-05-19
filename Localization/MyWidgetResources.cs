using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Localization;

namespace TheTrainingboss.SFADVDev.Localization
{
    [ObjectInfo(typeof(MyWidgetResources), ResourceClassId = "MyWidgetResources", Title = "MyWidgetResourcesTitle", TitlePlural = "MyWidgetResourcesTitlePlural", Description = "This is Myidget Resource")]
    public class MyWidgetResources: Resource
    {
        [ResourceEntry("Message", Value ="Message", Description = "Message in English", LastModified ="2021/05/19")]
        public string Message
        {
            get
            {
                return this["Message"];
            }
        }
    }
}