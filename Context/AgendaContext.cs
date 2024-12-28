using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_DIO_FRONT_END_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_DIO_FRONT_END_MVC.Context
{
    public class AgendaContext:DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options):base(options)
        {
            
        }
        public DbSet<Contato> Contatos { get; set; }
    }
}