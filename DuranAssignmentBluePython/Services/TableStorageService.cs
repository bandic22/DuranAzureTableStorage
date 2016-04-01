using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using System.Web.Mvc;
using DuranAssignmentBluePython.Models;

namespace DuranAssignmentBluePython.Services
{
    public class TableStorageService
    {
        public CloudTable table;

        public TableStorageService()
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            ConfigurationManager.AppSettings["StorageConnectionString"]);
            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            // Create the table if it doesn't exist.
            this.table = tableClient.GetTableReference("userEntity");
            table.CreateIfNotExists();
        }

        [HttpPost]
        public void PostUser(UserEntity userEntity)
        {
            var userEntity2 = new UserEntity(userEntity.Name, userEntity.Email);
            userEntity2.Age = userEntity.Age;
            userEntity2.Picture = userEntity.Picture;
            userEntity2.Name = userEntity.Name;
            userEntity2.Email = userEntity.Email;
            TableOperation insertOperation = TableOperation.Insert(userEntity2);
            this.table.Execute(insertOperation);
        }

        public List<UserEntity> GetUsers()
        {
            var userEntities = table.ExecuteQuery(new TableQuery<UserEntity>()).ToList();
            return userEntities;
        }

        [HttpPost]
        public UserEntity GetUserDetails(string name)
        {
            TableQuery<UserEntity> query = new TableQuery<UserEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, name));
            var user = this.table.ExecuteQuery(query).FirstOrDefault();
            return user;
        }
    }
}