using Recepten.Lib.Entities;
using Recepten.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepten.Lib.Services
{
    public class EmptyDataArtikelen : IArtikelData
    {
        public List<Artikel> Artikelen { get; set; }

        public EmptyDataArtikelen()
        {
            LaadArtikelen();
        }

        public void SlaOp(Artikel opTeSlaan, bool nietNodig)
        {
            //Geen verdere actie vereist
        }

        public void Verwijder(Artikel teVerwijderen)
        {
            //Geen verdere actie vereist
        }

        public void LaadArtikelen()
        {
            Artikelen = new List<Artikel>();
        }
    }
}
