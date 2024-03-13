using NewsForYou.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static NewsForYou.Model.Model;

namespace NewsForYou.DataAccess
{
    public class DataAccess
    {
        public static int IsUser(string email, string password)
        {
            int userId = 0;
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                    {
                        var user = context.Users.Single(x => x.Email == email);
                        if (user.Password == password)
                        {
                            userId = user.UserId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return userId;
        }

        public static int AddAgency(AgencyModel agency)
        {
            int agencyId = 0;
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    if (!string.IsNullOrEmpty(agency.AgencyName))
                    {
                        var existingAgency = context.Agencies.FirstOrDefault(a => a.AgencyName == agency.AgencyName);
                        if (existingAgency != null)
                        {
                            return agencyId;
                        }
                        Agency newAgency = new Agency
                        {
                            AgencyName = agency.AgencyName,
                            AgencyLogoPath = agency.AgencyLogoPath
                        };
                        context.Agencies.Add(newAgency);
                        context.SaveChanges();
                        agencyId = newAgency.AgencyId;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return agencyId;
        }

        public static int AddCategory(CategoryModel category)
        {
            int categoryId = 0;
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    if (!string.IsNullOrEmpty(category.CategoryTitle))
                    {
                        var existingCategory = context.Categories.FirstOrDefault(c => c.CategoryTitle == category.CategoryTitle);
                        if (existingCategory != null)
                        {
                            return categoryId;
                        }
                        Category newCategory = new Category
                        {
                            CategoryTitle = category.CategoryTitle
                        };
                        context.Categories.Add(newCategory);
                        context.SaveChanges();
                        categoryId = newCategory.CategoryId;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return categoryId;
        }

        public static int AddAgencyFeed(AgencyFeedModel agencyFeed)
        {
            int agencyFeedId = 0;
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    if (!string.IsNullOrEmpty(agencyFeed.AgencyFeedUrl) && agencyFeed.AgencyId != 0 && agencyFeed.CategoryId != 0)
                    {
                        var existingFeed = context.AgencyFeeds.FirstOrDefault
                                       (af => af.AgencyId == agencyFeed.AgencyId &&
                                        af.CategoryId == agencyFeed.CategoryId);

                        if (existingFeed != null)
                        {
                            return agencyFeedId;
                        }
                        AgencyFeed newAgencyFeed = new AgencyFeed
                        {
                            AgencyFeedUrl = agencyFeed.AgencyFeedUrl,
                            AgencyId = agencyFeed.AgencyId,
                            CategoryId = agencyFeed.CategoryId
                        };
                        context.AgencyFeeds.Add(newAgencyFeed);
                        context.SaveChanges();
                        agencyFeedId = newAgencyFeed.AgencyFeedId;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return agencyFeedId;
        }

        public static void DeleteAllNews()
        {
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    context.News.RemoveRange(context.News);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public static List<Agency> GetAgencies()
        {
            List<Agency> agencyList = new List<Agency>();
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    agencyList = context.Agencies.ToList();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
            return agencyList;
        }

        public static List<Category> GetCategories()
        {
            List<Category> categoryList = new List<Category>();
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    categoryList = context.Categories.ToList();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
            return categoryList;
        }

        public static List<CategoryModel> GetCategoriesByAgencyId(int agencyId)
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    categoryList = context.AgencyFeeds
                        .Where(feed => feed.AgencyId == agencyId)
                        .Select(feed => new CategoryModel
                        {
                            CategoryId = feed.Category.CategoryId,
                            CategoryTitle = feed.Category.CategoryTitle
                        })
                        .ToList();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }
            return categoryList;
        }

        public static string GetNewsByCategory(int categoryId, int agencyId)
        {
            string agencyFeedUrl = null;

            try
            {
                using (var context = new NewsForYouEntities())
                {
                    agencyFeedUrl = context.AgencyFeeds
                        .Where(feed => feed.AgencyId == agencyId && feed.CategoryId == categoryId)
                        .Select(feed => feed.AgencyFeedUrl)
                        .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }

            return agencyFeedUrl;
        }

        public static bool AddNewsToDatabase(List<NewsDataViewModel> newsData, int categoryId, int agencyId)
        {
            bool newsAdded = false;
            try
            {
                using (var context = new NewsForYouEntities())
                {
                    foreach (var newsItem in newsData)
                    {
                        bool newsExists = context.News.Any(news => news.NewsLink == newsItem.NewsLink);

                        if (!newsExists)
                        {
                            News newsEntity = new News
                            {
                                NewsTitle = newsItem.NewsTitle,
                                NewsDescription = newsItem.NewsDescription,
                                NewsLink = newsItem.NewsLink,
                                NewsPublishDateTime = newsItem.NewsPublishDateTime,
                                CategoryId = categoryId,
                                AgencyId = agencyId
                            };
                            context.News.Add(newsEntity);
                            newsAdded = true;
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logger.LogError(e);
            }

            return newsAdded;
        }

        public static List<NewsDataViewModel> GetAllNews(int agencyId)
        {
            using (var context = new NewsForYouEntities())
            {
                var newsFromDb = context.News
                    .Where(news => news.AgencyId == agencyId)
                    .OrderByDescending(news => news.NewsPublishDateTime)
                    .Select(news => new NewsDataViewModel
                    {
                        NewsId = news.NewsId,
                        NewsTitle = news.NewsTitle,
                        NewsDescription = news.NewsDescription,
                        NewsLink = news.NewsLink,
                        NewsPublishDateTime = news.NewsPublishDateTime
                    })
                    .ToList();

                return newsFromDb;
            }
        }

        public static List<NewsDataViewModel> GetNewsFromDatabase(List<int> categoryIds, int agencyId)
        {
            using (var context = new NewsForYouEntities())
            {
                var newsFromDb = context.News
                    .Where(news => categoryIds.Contains(news.CategoryId) && news.AgencyId == agencyId)
                    .OrderByDescending(news => news.NewsPublishDateTime)
                    .Select(news => new NewsDataViewModel
                    {
                        NewsId = news.NewsId,
                        NewsTitle = news.NewsTitle,
                        NewsDescription = news.NewsDescription,
                        NewsLink = news.NewsLink,
                        NewsPublishDateTime = news.NewsPublishDateTime
                    })
                    .ToList();

                return newsFromDb;
            }
        }

        public static void IncrementNewsClickCount(int newsId)
        {
            using (var context = new NewsForYouEntities())
            {
                var newsItem = context.News.Find(newsId);
                if (newsItem != null)
                {
                    if (newsItem.ClickCount == null)
                    {
                        newsItem.ClickCount = 1;
                    }
                    else
                    {
                        newsItem.ClickCount++;
                    }
                    context.SaveChanges();
                }
            }
        }

        public static int GetTotalNewsCount(DateTime startDate, DateTime endDate)
        {
            using (var context = new NewsForYouEntities())
            {
                return context.News.Count(n => n.NewsPublishDateTime >= startDate.Date && n.NewsPublishDateTime <= endDate.Date);
            }
        }

        public static List<ClickCountReportModel> GenerateClickCountReport(DateTime startDate, DateTime endDate, int page, int pageSize)
        {
            using (var context = new NewsForYouEntities())
            {
                var query = context.News.AsQueryable();

                var paginatedData = query.Where(n => n.NewsPublishDateTime >= startDate.Date && n.NewsPublishDateTime <= endDate.Date)
                                        .OrderByDescending(n => n.ClickCount)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)

                                        .Select(n => new ClickCountReportModel
                                        {
                                            AgencyName = n.Agency.AgencyName,
                                            CategoryTitle = n.Category.CategoryTitle,
                                            NewsTitle = n.NewsTitle,
                                            ClickCount = n.ClickCount
                                        }).ToList();

                return paginatedData;
            }
        }

        public static List<ClickCountReportModel> GeneratePdf(DateTime startDate, DateTime endDate)
        {
            using (var context = new NewsForYouEntities())
            {
                var allNews = context.News
                    .Where(n => n.NewsPublishDateTime >= startDate.Date && n.NewsPublishDateTime <= endDate.Date)
                    .OrderByDescending(news => news.ClickCount)
                    .Select(news => new ClickCountReportModel
                    {
                        AgencyName = news.Agency.AgencyName,
                        CategoryTitle = news.Category.CategoryTitle,
                        NewsTitle = news.NewsTitle,
                        ClickCount = news.ClickCount
                    })
                    .ToList();

                return allNews;
            }
        }
    }
}
