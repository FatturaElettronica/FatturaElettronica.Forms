using System.Linq;
using FatturaElettronica.Tabelle;

namespace FatturaElettronica.Forms
{
    public class IdPaeseNullable : IdPaese
    {

        public override Tabella[] List
        {
            get
            {
                var baseList = base.List.ToList();
                baseList.Insert(0, new IdPaeseNullable { Codice = string.Empty, Nome = string.Empty });
                return baseList.ToArray();
            }
        }
    }
}
