using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsForYou.Model
{
    public class Model
    {
        public class SignInModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class AgencyModel
        {
            public int AgencyId { get; set; }
            public string AgencyName { get; set; }
            public string AgencyLogoPath { get; set; }
        }

        public class CategoryModel
        {
            public int CategoryId { get; set; }
            public string CategoryTitle { get; set; }
        }

        public class AgencyFeedModel
        {
            public int AgencyFeedId { get; set; }
            public string AgencyFeedUrl { get; set; }
            public int AgencyId { get; set; }
            public int CategoryId { get; set; }
        }

        public class NewsDataViewModel
        {
            public int NewsId { get; set; }
            public string NewsTitle { get; set; }
            public string NewsDescription { get; set; }
            public DateTime NewsPublishDateTime { get; set; }
            public string NewsLink { get; set; }
            public int ClickCount { get; set; }
            public int CategoryId { get; set; }
            public int AgencyId { get; set; }
        }

        public class ClickCountReportModel
        {
            public string AgencyName { get; set; }
            public string CategoryTitle { get; set; }
            public string NewsTitle { get; set; }
            public int? ClickCount { get; set; }
        }
    }
}
