using System.Linq;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Forms
{
    public class SoggettoEmittenteNullable : SoggettoEmittente
    {

        public override Tabella[] List
        {
            get
            {
                var baseList = base.List.ToList();
                baseList.Insert(0, new SoggettoEmittenteNullable { Codice = string.Empty, Nome = string.Empty });
                return baseList.ToArray();
            }
        }
    }
}
