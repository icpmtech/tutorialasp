using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication5.Areas.Administration;

namespace WebApplication5.Areas.ElasticSearch.Controllers
{
    public class SearchController : ApiController
    {
        SearchApi.ConnectionToNest SearchApi;
        public SearchController()
        {
            SearchApi = new SearchApi.ConnectionToNest();
        }
        // GET: api/Search
        public  async Task<string> GetAsync()
        {
            var searchResponse = await SearchApi.ElasticLowLevelClient.SearchAsync<StringResponse>("user", PostData.Serializable(new
            {
                from = 0,
                size = 10
                
            }));
            var successful = searchResponse.Success;
            var responseJson = searchResponse.Body;
            return responseJson;
        }

        // GET: api/Search/5
        public async Task<IEnumerable<UserModel>> GetAsync(string name)
        {
            var searchRequest = new SearchRequest<UserModel>(Nest.Indices.All)
            {
                From = 0,
                Size = 10,
                Query = new MatchQuery
                {
                    Field = Infer.Field<UserModel>(f => f.Name),
                    Query = name
                }
            };

            var searchResponse = await SearchApi.ElasticClient.SearchAsync<UserModel>(searchRequest);
           

            return searchResponse.Documents;
        }

        // POST: api/Search
        public  void Post(UserModel user)
        {
            try
            {
                var ndexResponse = SearchApi.ElasticClient.IndexDocument(user);

                var asyncIndexResponse =  SearchApi.ElasticClient.IndexDocument(user);

              

            }
            catch (Exception ex)
            {

                throw ex;
            }
          

        }

        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
    }
}
