using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuranAssignmentBluePython.Models
{
    public class UserEntity : TableEntity
    {
        public UserEntity(string name, string email)
        {
            this.PartitionKey = name;
            this.RowKey = email;
        }

        public UserEntity() { }

        public int Age { get; set; }
        public byte[] Picture { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
