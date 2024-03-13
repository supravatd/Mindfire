using NewsForYou.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static NewsForYou.Model.Model;

namespace NewsForYou.Business
{
    public class Business
    {
        public static List<AgencyModel> GetAgencies()
        {
            List<Agency> agencies = DataAccess.DataAccess.GetAgencies();
            List<AgencyModel> agencyModels = new List<AgencyModel>();

            foreach (var agency in agencies)
            {
                AgencyModel agencyModel = new AgencyModel
                {
                    AgencyId = agency.AgencyId,
                    AgencyName = agency.AgencyName,
                    AgencyLogoPath = agency.AgencyLogoPath
                };

                agencyModels.Add(agencyModel);
            }

            return agencyModels;
        }

        public static List<CategoryModel> GetCategories()
        {
            List<Category> categories = DataAccess.DataAccess.GetCategories();
            List<CategoryModel> allCategories = new List<CategoryModel>();

            foreach (var category in categories)
            {
                CategoryModel allCategory = new CategoryModel
                {
                    CategoryId = category.CategoryId,
                    CategoryTitle = category.CategoryTitle
                };

                allCategories.Add(allCategory);
            }
            return allCategories;
        }

        public static int AddAgency(AgencyModel agency)
        {
            return DataAccess.DataAccess.AddAgency(agency);
        }

        public static int AddCategory(CategoryModel category)
        {
            return DataAccess.DataAccess.AddCategory(category);
        }

        public static int AddAgencyFeed(AgencyFeedModel agencyFeed)
        {
            return DataAccess.DataAccess.AddAgencyFeed(agencyFeed);
        }

        public static void DeleteAllNews()
        {
            DataAccess.DataAccess.DeleteAllNews();
        }

        public static List<CategoryModel> GetCategoriesByAgencyId(int agencyId)
        {
            return DataAccess.DataAccess.GetCategoriesByAgencyId(agencyId);
        }

        public static int IsUser(string email, string password)
        {
            return DataAccess.DataAccess.IsUser(email, password);
        }

        public static List<NewsDataViewModel> GetAllNews(int agencyId)
        {
            return DataAccess.DataAccess.GetAllNews(agencyId);
        }

        public static List<ClickCountReportModel> GeneratePdf(DateTime startDate, DateTime endDate)
        {
            return DataAccess.DataAccess.GeneratePdf(startDate, endDate);
        }

        public static (List<NewsDataViewModel> newsData, bool newsAdded) GetNewsByCategories(List<int> categories, int agencyId)
        {
            var newsAdded = false;
            if (categories != null && categories.Any() && agencyId > 0) 
            {
                foreach (int categoryId in categories)
                {
                    string agencyFeedUrl = DataAccess.DataAccess.GetNewsByCategory(categoryId, agencyId);
                    if (!string.IsNullOrEmpty(agencyFeedUrl)) 
                    {
                        string xmlData = FetchXmlData(agencyFeedUrl);
                        if (!string.IsNullOrEmpty(xmlData)) 
                        {
                            List<NewsDataViewModel> newsData = ParseXmlData(xmlData);
                            if (newsData != null && newsData.Any())
                            {
                                newsAdded |= DataAccess.DataAccess.AddNewsToDatabase(newsData, categoryId, agencyId);
                            }
                        }
                    }
                }
            }
            else
            {
                return (new List<NewsDataViewModel>(), false);
            }
            List<NewsDataViewModel> newsDataFromDb = DataAccess.DataAccess.GetNewsFromDatabase(categories, agencyId);
            return (newsDataFromDb, newsAdded);
        }

        private static string FetchXmlData(string agencyFeedUrl)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(agencyFeedUrl);
            }
        }

        private static List<NewsDataViewModel> ParseXmlData(string xmlData)
        {
            List<NewsDataViewModel> newsDataList = new List<NewsDataViewModel>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlData);

            XmlNodeList itemNodes = xmlDoc.SelectNodes("//item");

            foreach (XmlNode itemNode in itemNodes)
            {
                string title = itemNode.SelectSingleNode("title")?.InnerText;
                string description = itemNode.SelectSingleNode("description")?.InnerText;
                string link = itemNode.SelectSingleNode("link")?.InnerText;
                string pubDateTimeStr = itemNode.SelectSingleNode("pubDate")?.InnerText;

                DateTime pubDateTime;
                if (DateTime.TryParse(pubDateTimeStr, out pubDateTime))
                {
                    newsDataList.Add(new NewsDataViewModel
                    {
                        NewsTitle = title,
                        NewsDescription = description,
                        NewsLink = link,
                        NewsPublishDateTime = pubDateTime
                    });
                }
            }

            return newsDataList;
        }

        public static void IncrementNewsClickCount(int newsId)
        {
            DataAccess.DataAccess.IncrementNewsClickCount(newsId);
        }

        public static (List<ClickCountReportModel> ReportData, int TotalPages) GenerateClickCountReport(DateTime startDate, DateTime endDate, int page, int pageSize)
        {
            var reportData = DataAccess.DataAccess.GenerateClickCountReport(startDate, endDate, page, pageSize);
            var totalCount = DataAccess.DataAccess.GetTotalNewsCount(startDate, endDate); 
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            return (reportData, totalPages);
        }
    }
}
