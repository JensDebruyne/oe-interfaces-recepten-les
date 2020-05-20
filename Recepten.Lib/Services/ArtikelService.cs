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
    }
}
