using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Internal;
using Amazon.Runtime;
using MonoToMicroLambda.Core.Data.Interfaces;
using MonoToMicroLambda.Core.Data.Models;

namespace MonoToMicroLambda.Core.Data.Implementation
{
    public class UnicornData : IUnicornData
    {
        private static AmazonDynamoDBClient _instance;    

        public static AmazonDynamoDBClient _client
        {
            get
            {
                if (_instance == null)
                    _instance = new AmazonDynamoDBClient(new EnvironmentVariablesAWSCredentials()
                    {
                        
                    }, RegionEndpoint.USEast1);

                return _instance;
            }
        }

        public List<Unicorn> GetUnicorns()
        {
           
            throw new System.NotImplementedException();
        }

        public async Task<bool> AddUnicornToBasket(string userUuid, string unicornUuid)
        {
            using (var context = new DynamoDBContext(_client))
            {
                try
                {
                    await context.SaveAsync(new UnicornBasket()
                    {
                        Uuid = userUuid,
                        UnicornUuid = unicornUuid
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                

                return true;
            }
        }

        public async Task<bool> RemoveUnicornFromBasket(string userUuid, string unicornUuid)
        {
            using (var context = new DynamoDBContext(_client))
            {
                await context.DeleteAsync(new UnicornBasket()
                {
                    Uuid = userUuid,
                    UnicornUuid = unicornUuid
                });

                return true;
            }
        }

        public async Task<List<UnicornBasket>> GetUnicornBasket(string userUuid)
        {
            using (var context = new DynamoDBContext(_client))
            {
                var returnUnicorns = new List<UnicornBasket>();
                var queryResults = context.QueryAsync<UnicornBasket>(userUuid);

                while (!queryResults.IsDone)
                {
                    var result = await queryResults.GetNextSetAsync() ?? await queryResults.GetRemainingAsync();
                    returnUnicorns.AddRange(
                        result
                    );
                }

                return returnUnicorns;
            }
        }

        public List<UnicornBasket> GetAllBaskets()
        {
            throw new System.NotImplementedException();
        }
    }
}