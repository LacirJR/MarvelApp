using MarvelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelApp.Gateway.Interfaces
{
    public interface IHttpService
    {
        Task<Characters> GetCharacters();
    }
}
