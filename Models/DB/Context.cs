using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcOnlineTicariOtomasyon.Models.Entities;

namespace MvcOnlineTicariOtomasyon.Models.DB
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Concubine> Concubines { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicePen> InvoicePens { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesMove> salesMoves { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<CargoDetay> cargoDetays { get; set; }
        public DbSet<CargoTakip> cargoTakips { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}