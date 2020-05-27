using Recepten.Lib.Entities;
using Recepten.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recepten.Lib.Services
{
    public class ArtikelService
    {
        private IArtikelData gekozenDataSource;
        
        public List<Artikel> Artikelen { get; set; }

        public ArtikelService(IArtikelData dataSource)
        {
            Artikelen = dataSource.Artikelen;
            gekozenDataSource = dataSource;
        }

        public void Verwijder(Artikel teVerwijderen)
        {
            gekozenDataSource.Verwijder(teVerwijderen);
        }

        public void SlaOp(Artikel opTeSlaan)
        {
            gekozenDataSource.SlaOp(opTeSlaan);
        }

        public static int GeefIndexInLijst(Artikel teChecken, List<Artikel> artikelen)
        {
            int indexTeCheckenInstance = -1;
            for (int i = 0; i < artikelen.Count; i++)
            {
                if (artikelen[i].Id == teChecken.Id)
                {
                    indexTeCheckenInstance = i;
                    break;
                }
            }
            return indexTeCheckenInstance;
        }

        static bool BehoortObjectTotLijst(Artikel teChecken, List<Artikel> artikelen)
        {
            bool gevonden = false;
            foreach (Artikel instance in artikelen)
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
