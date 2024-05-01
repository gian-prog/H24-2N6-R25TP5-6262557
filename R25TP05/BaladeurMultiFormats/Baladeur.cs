using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    internal class Baladeur : IBaladeur
    {
        #region  Champs et Propriétés
        /// <summary>
        /// Initialise une instance de la classe Baladeur. Elle instancie la collection des chansons.
        /// </summary>
        private List<Chanson> m_colChansons;

        /// <summary>
        /// Nom du réportoire
        /// </summary>
        private const string NOM_RÉPERTOIRE = "Chansons";

        public int NbChansons { get { return m_colChansons.Count; } }

        #endregion
        #region Méthodes
        public void AfficherLesChansons(ListView pListView)
        {
            throw new NotImplementedException();
        }

        public Chanson ChansonAt(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConstruireLaListeDesChansons()
        {
            throw new NotImplementedException();

        }

        public void ConvertirVersAAC(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersMP3(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersWMA(int pIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Constructeurs
        /// <summary>
        /// Initialise une instance de la classe Baladeur. Elle instancie la collection des chansons.
        /// </summary>
        public Baladeur() { m_colChansons = new List<Chanson>(); }
        #endregion
    }
}
