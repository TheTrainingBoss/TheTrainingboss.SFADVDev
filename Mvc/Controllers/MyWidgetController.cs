/* ------------------------------------------------------------------------------
<auto-generated>
    This file was generated by Sitefinity CLI v1.1.0.9
</auto-generated>
------------------------------------------------------------------------------ */

using TheTrainingboss.SFADVDev.Mvc.Models;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Personalization;
using System;
using Progress.Sitefinity.Renderer.Entities.Content;
using Progress.Sitefinity.Renderer.Designers.Attributes;

namespace TheTrainingboss.SFADVDev.Mvc.Controllers
{
	[ControllerToolboxItem(Name = "MyWidget", Title = "My Widget", SectionName = "SFADVDev")]
	public class MyWidgetController : Controller, IPersonalizable
	{
		// GET: MyWidget
		public ActionResult Index()
		{
			var model = new MyWidgetModel();
			model.Message = this.Message;
			model.Flag = this.Flag;
			model.Enum = this.Enum;
			model.Number = this.Number;
			model.MyDate = this.MyDate;
			return View(model);
		}

		public ActionResult Raja()
		{
			var model = new MyWidgetModel();
			model.Message = this.Message;
			return View(model);
		}

		protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

		public string Message { get; set; }
		public bool Flag { get; set; }
		public Enumeration Enum { get; set; }
		public int Number { get; set; }
		public DateTime MyDate { get; set; }
		[Content(Type = KnownContentTypes.News)]
		public MixedContentContext News { get; set; }

		[Content(Type = KnownContentTypes.News, LiveData = true)]
		public MixedContentContext NewsLive { get; set; }

		[Content(Type = KnownContentTypes.Pages, AllowMultipleItemsSelection = false)]
		public MixedContentContext Page { get; set; }

		[Content(Type = KnownContentTypes.Images)]
		public MixedContentContext Images { get; set; }

		[TaxonomyContent(Type = KnownContentTypes.Tags)]
		public MixedContentContext Tags { get; set; }

}
}