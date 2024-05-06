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
            pListView.Items.Clear();
            foreach (Chanson chans in m_colChansons)
            {
                ListViewItem vue = new ListViewItem(chans.Artiste);
                vue.SubItems.Add(chans.Titre);
                vue.SubItems.Add(chans.Annee.ToString());
                vue.SubItems.Add(chans.Format);
                pListView.Items.Add(vue);
            }
        }

        public Chanson ChansonAt(int pIndex)
        {
            if (pIndex != -1)
            {
                return m_colChansons[pIndex];
            }
            return null;
        }

        public void ConstruireLaListeDesChansons()
        {
            try
            {

                if (Directory.Exists(NOM_RÉPERTOIRE))
                {
                    string[] fichiertab = Directory.GetFiles(NOM_RÉPERTOIRE);
                    Array.Sort(fichiertab);
                    foreach (string file in fichiertab)
                    {
                        if (File.Exists(file))
                        {
                            int cpt = 0;
                            try
                            {
                                switch (file.Substring(file.Length - 3).ToUpper())
                                {
                                    case "AAC":
                                        ChansonAAC chansonAAC = new ChansonAAC(file);
                                        m_colChansons.Add(chansonAAC);
                                        break;
                                    case "MP3":
                                        ChansonMP3 chansonMP3 = new ChansonMP3(file);
                                        m_colChansons.Add(chansonMP3);
                                        break;
                                    case "WMA":
                                        ChansonWMA chansonWMA = new ChansonWMA(file);
                                        m_colChansons.Add(chansonWMA);
                                        break;
                                }
                            }
                            catch (Exception)
                            {
                                cpt++;
                                MessageBox.Show("Baladeur",cpt+"chansons n'ont pu être chargées correctement",MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Baladeur", "Impossible de trouver le dossier contenant les chansons ! ",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ConvertirVersAAC(int pIndex)
        {
            string fileName = m_colChansons[pIndex].NomFichier;
            ChansonAAC chansAAC = new ChansonAAC(NOM_RÉPERTOIRE, m_colChansons[pIndex].Artiste, m_colChansons[pIndex].Titre, m_colChansons[pIndex].Annee);
            chansAAC.Ecrire(m_colChansons[pIndex].Paroles);
            File.Delete(fileName);
            m_colChansons.RemoveAt(pIndex);
            m_colChansons.Add(chansAAC);        
        }

        public void ConvertirVersMP3(int pIndex)
        {
            string fileName = m_colChansons[pIndex].NomFichier;
            ChansonMP3 chansMP3 = new ChansonMP3(NOM_RÉPERTOIRE, m_colChansons[pIndex].Artiste, m_colChansons[pIndex].Titre, m_colChansons[pIndex].Annee);
            chansMP3.Ecrire(m_colChansons[pIndex].Paroles);
            File.Delete(fileName);
            m_colChansons.RemoveAt(pIndex);
            m_colChansons.Add(chansMP3);
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
