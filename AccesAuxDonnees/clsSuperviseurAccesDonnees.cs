using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesAuxDonnees
{
    public class clsSuperviseurAccesDonnees : clsPersonnesAccesDonnees
    {
        public override void CreerPersonnes()
        {
            throw new NotImplementedException();
        }

        public override DataTable RecupererListePersonnes(int iID = 0)
        {
            throw new NotImplementedException();
        }

        public override void SupprimerPersonne()
        {
            throw new NotImplementedException();
        }
    }
}
