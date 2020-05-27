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
            if (opTeSlaan == null) throw new Exception("Geef een geldig artikel door om op te slaan");
            else if (!BehoortObjectTotLijst(opTeSlaan)) Artikelen.Add(opTeSlaan);
            else
            {
                int indexObject = GeefIndexInLijst(opTeSlaan);
                Artikelen[indexObject] = opTeSlaan;
            }
        }

        public void Verwijder(Artikel teVerwijderen)
        {
            if (teVerwijderen != null && BehoortObjectTotLijst(teVerwijderen))
            {
                Artikelen.Remove(teVerwijderen);
            }
            else throw new Exception("Geef een geldig artikel door om te verwijderen");
        }

        int GeefIndexInLijst(Artikel teChecken)
        {
            int indexTeCheckenInstance = -1;
            for (int i = 0; i < Artikelen.Count; i++)
            {
                if (Artikelen[i].Id == teChecken.Id)
                {
                    indexTeCheckenInstance = i;
                    break;
                }
            }
            return indexTeCheckenInstance;
        }

        bool BehoortObjectTotLijst(Artikel teChecken)
        {
            bool gevonden = false;
            foreach (Artikel instance in Artikelen)
            {
                if (instance.Id == teChecken.Id)
                {
                    gevonden = true;
                    break;
                }
            }
            return gevonden;
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
