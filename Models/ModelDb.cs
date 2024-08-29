using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace volksoft.Models
{
    public class ModelDb : DbContext
    {
        public ModelDb() : base("default")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryModel> States { get; set; }
    }
}