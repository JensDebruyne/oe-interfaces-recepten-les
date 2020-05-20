using Recepten.Lib.Entities;
using Recepten.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileStreams.Lib;

namespace Recepten.Lib.Services
{
    //De data uit Artikelen.csv moeten langs deze klasse ingeladen en bewerkt kunnen worden.
    public class TextFileDataArtikelen : IArtikelData
    {
        public List<Artikel> Artikelen { get ; set; }

        public void LaadArtikelen()
        {

        }

        public void SlaOp(Artikel opTeSlaan)
        {

        }

        public void Verwijder(Artikel teVerwijderen)
        {

        }
    }
}
