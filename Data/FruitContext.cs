using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FruitWebApiREST.Models;

namespace FruitWebApiREST.Data
{
    public class FruitContext : DbContext
    {
        // Declaração do "DbSet" que representa a tabela dinamicamente
        public DbSet<Fruits> Fruit { get; set; }

        // Função FruitContext()
        public FruitContext(DbContextOptions<FruitContext> options):base(options)
        {

        }

    }
}
