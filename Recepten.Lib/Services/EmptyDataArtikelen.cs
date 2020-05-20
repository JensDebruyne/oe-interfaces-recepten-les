using Recepten.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepten.Lib.Services
{
    public class EmptyDataArtikelen
    {
        public List<Artikel> Artikelen { get; set; }

        public EmptyDataArtikelen()
        {
            Artikelen = new List<Artikel>();
        }

        public void SlaOp(Artikel opTeSlaan)
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

    }
}
