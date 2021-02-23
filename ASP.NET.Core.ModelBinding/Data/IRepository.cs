using ASP.NET.Core.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET.Core.WebApp.Data
{
    public interface IRepository
    {
        IEnumerable<Person> People { get; }
        Person this[int id] { get; set; }
    }
}
