using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Microsoft.Practices.Unity.InterceptionExtension;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.OA;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Lifecycle;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.News.Model;
using Telerik.Sitefinity.Security.Model;

namespace TheTrainingboss.SFADVDev.Providers
{
    [ApplyNoPolicies]
    public class CustomNewsProvider : NewsDataProvider, IOpenAccessDataProvider
    {
        public OpenAccessProviderContext Context { get; set; }

        public override NewsItem GetNewsItem(Guid id)
        {
            return this.GetNewsItems().First(n => n.Id == id);
        }

        public override IQueryable<NewsItem> GetNewsItems()
        {
            NewsItem item1 = App.WorkWith().NewsItem().CreateNew(Guid.Parse("91D8FE12-128D-43C2-8661-96ADDDD3AE64")).Get();
            item1.Title = "First news";
            item1.Summary = "First news summary";
            item1.Content = "Malcolm Turnbull has made it OK to make judgments about our elected representatives on moral or character grounds";
            item1.Visible = true;
            item1.UrlName = "first-news";
            item1.Status = ContentLifecycleStatus.Master;
            item1.LastModified = DateTime.UtcNow;
            item1.ApplicationName = this.ApplicationName;
            item1.ItemDefaultUrl = "/" + item1.UrlName;
            item1.SetWorkflowStatus(this.ApplicationName, "Published");
            item1.Provider = this;

            NewsItem item1Live = App.WorkWith().NewsItem().CreateNew(Guid.Parse("0E4347B1-F649-437A-BB93-7471AB6ED635")).Get();
            item1Live.Title = "First news";
            item1Live.Summary = "First news summary";
            item1Live.Content = "Malcolm Turnbull has made it OK to make judgments about our elected representatives on moral or character grounds";
            item1Live.Visible = true;
            item1Live.UrlName = "/first-news";
            item1Live.Status = ContentLifecycleStatus.Live;
            item1Live.OriginalContentId = item1.Id;
            item1Live.LastModified = DateTime.UtcNow;
            item1Live.ApplicationName = this.ApplicationName;
            item1Live.ItemDefaultUrl = "/" + item1Live.UrlName;
            item1Live.SetWorkflowStatus(this.ApplicationName, "Published");
            item1Live.Provider = this;

            var item2 = App.WorkWith().NewsItem().CreateNew(Guid.Parse("6519FE99-116E-4B76-8C5C-5EB9505D6F2F")).Get();
            item2.Title = "Second news";
            item2.Summary = "Second news summary";
            item2.Content = "The Australian prime minister, Malcolm Turnbull, announces changes to ministerial standards around relationships with staffers";
            item2.Status = ContentLifecycleStatus.Master;
            item2.Visible = true;
            item2.UrlName = "second-news";
            item2.LastModified = DateTime.UtcNow;
            item2.ApplicationName = this.ApplicationName;
            item2.ItemDefaultUrl = "/" + item2.UrlName;
            item2.SetWorkflowStatus(this.ApplicationName, "Published");
            item2.Provider = this;

            NewsItem item2Live = App.WorkWith().NewsItem().CreateNew(Guid.Parse("96C13301-2CB0-4D6C-A95E-8F3F7D9D511A")).Get();
            item2Live.Title = "Second news";
            item2Live.Summary = "Second news summary";
            item2Live.Content = "The Australian prime minister, Malcolm Turnbull, announces changes to ministerial standards around relationships with staffers";
            item2Live.Visible = true;
            item2Live.UrlName = "second-news";
            item2Live.Status = ContentLifecycleStatus.Live;
            item2Live.OriginalContentId = item2.Id;
            item2Live.LastModified = DateTime.UtcNow;
            item2Live.ApplicationName = this.ApplicationName;
            item2Live.ItemDefaultUrl = "/" + item2Live.UrlName;
            item2Live.SetWorkflowStatus(this.ApplicationName, "Published");
            item2Live.Provider = this;

            return new List<NewsItem>()
            {
                item1,
                item1Live,
                item2,
                item2Live
            }.AsQueryable();
        }

        public override IDataItem GetItemFromUrl(Type itemType, string url, bool published, out string redirectUrl)
        {
            redirectUrl = null;
            return this.GetNewsItems().First(i => i.ItemDefaultUrl == url);
        }

        protected override Guid GetNewGuid()
        {
            return Guid.NewGuid();
        }

        public override ISecuredObject GetSecurityRoot(bool create)
        {
            var key = String.Concat(this.RootKey, this.Name);
            return new SecurityRoot(this.Name, this.GetNewGuid(), this.SupportedPermissionSets, this.PermissionsetObjectTitleResKeys) { Key = key };
        }

        public override NewsItem CreateNewsItem()
        {
            throw new NotImplementedException();
        }

        public override NewsItem CreateNewsItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public override void Delete(NewsItem newsItemToDelete)
        {
            throw new NotImplementedException();
        }

        public override LanguageData CreateLanguageData()
        {
            throw new NotImplementedException();
        }

        public override LanguageData CreateLanguageData(Guid id)
        {
            throw new NotImplementedException();
        }

        public override LanguageData GetLanguageData(Guid id)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<LanguageData> GetLanguageData()
        {
            throw new NotImplementedException();
        }

        public MetadataSource GetMetaDataSource(IDatabaseMappingContext context)
        {
            return new SecuredProviderMetadataSource(context);
        }
    }
}
