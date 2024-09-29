using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using my_orange_easyxls.Models;

namespace my_orange_easyxls.Data
{
    public class MyOrangePMPProjectContext : DbContext
    {
        public MyOrangePMPProjectContext (DbContextOptions<MyOrangePMPProjectContext> options)
            : base(options)
        {
        }

        public DbSet<my_orange_easyxls.Models.Org_file> OrgFile { get; set; } = default!;


        // public DbSet<myorange_pmproject.Models.Manager> Manager { get; set; } = default!;

        // public DbSet<myorange_pmproject.Models.Menu> Menu { get; set; } = default!;


        //public DbSet<myorange_pmproject.Models.Menu_ruler> Menu_ruler { get; set; } = default!;


        //public DbSet<myorange_pmproject.Models.User_need> User_need { get; set; } = default!;



        //public DbSet<myorange_pmproject.Models.User_authorize_code> User_authorize_code { get; set; } = default!;

        //public DbSet<myorange_pmproject.Models.User> User { get; set; } = default!;

        //public DbSet<myorange_pmproject.Models.Project> Project { get; set; } = default!;

        //public DbSet<myorange_pmproject.Models.Project_request> ProjectRequest { get; set; } = default!;

        //public DbSet<myorange_pmproject.Models.Project_document> ProjectDocument { get; set; } = default!;
        //Project_project_document_list
        //public DbSet<myorange_pmproject.Models.Project_project_document_list> ProjectDocumentList { get; set; } = default!;
        //public DbSet<myorange_pmproject.Models.Project_request_list> ProjectRequestList { get; set; } = default!;
        //Project_request_list
        public IQueryable<T> GetQueryable<T>() where T : class
        {
            var dbSetProperty = GetType().GetProperty(typeof(T).Name, BindingFlags.Public | BindingFlags.Instance);
            if (dbSetProperty == null)
                throw new InvalidOperationException($"No DbSet<{typeof(T).Name}> found in the DbContext.");

            return (IQueryable<T>)dbSetProperty.GetValue(this);
        }

        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<News>()
                .Property(b => b.Title)
                .IsRequired();
        
             */
            /*
      
            */ 

        } 

    }

}
