using Recepten.Lib.Entities;
using Recepten.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepten.Lib.Services
{
    public class MockDataArtikelen : IArtikelData
    {
        public List<Artikel> Artikelen { get; set; }

        public MockDataArtikelen()
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
            Artikelen = new List<Artikel>
            {
                new Artikel("ei", "Stuk", 0.25M),
                new Artikel("ui", "Kg", 0.65M),
                new Artikel("kreeft", "Stuk", 24.50M)
            };
        }
    }
}
