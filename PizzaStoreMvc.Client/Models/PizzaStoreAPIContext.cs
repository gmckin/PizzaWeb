using PizzaStoreMvc.Client.DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PizzaStoreMvc.Client.Models
{
    public class PizzaStoreAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PizzaStoreAPIContext() : base("name=PizzaStoreAPIContext")
        {
        }

    public System.Data.Entity.DbSet<PizzaStoreMvc.Client.DomainModels.Customer> Customers { get; set; }

    public System.Data.Entity.DbSet<PizzaStoreMvc.Client.DomainModels.Pizza> Pizzas { get; set; }
    public DbSet<Address>Addresses { get; set; }
    public DbSet<Cheese>Cheeses { get; set; }
    public DbSet<Crust>Crusts { get; set; }
    public DbSet<Email>Emails { get; set; }
    public DbSet<Name>Names { get; set; }
    public DbSet<Order>Orders { get; set; }
    public DbSet<Phone>Phones { get; set; }
    //public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Sauce>Sauces { get; set; }
    public DbSet<Size>Sizes { get; set; }
    public DbSet<Topping>Toppings { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<Zip> Zip { get; set; }

    public System.Data.Entity.DbSet<PizzaStoreMvc.Client.DomainModels.Store> Stores { get; set; }

    public System.Data.Entity.DbSet<PizzaStoreMvc.Client.DomainModels.PizzaTopping> PizzaToppings { get; set; }

    public System.Data.Entity.DbSet<PizzaStoreMvc.Client.DomainModels.PizzaCheese> PizzaCheese { get; set; }
  }
}
