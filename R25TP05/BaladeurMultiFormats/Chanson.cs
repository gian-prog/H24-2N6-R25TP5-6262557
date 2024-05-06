using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {
        #region Propriétés
        protected int m_annee;
        public int Annee { get { return m_annee; } }

        protected string m_artiste;
        public string Artiste { get { return m_artiste; } }

        public abstract string Format { get; }

        protected string m_nomFichier;
        public string NomFichier { get { return m_nomFichier; } }

        public string Paroles
        {
            get
            {
                if (File.Exists(m_nomFichier))
                {
                    StreamReader reader = new StreamReader(m_nomFichier);
                    SauterEntete(reader);
                    string paroles = LireParoles(reader);
                    reader.Close();
                    return paroles;
                }
                return null;
            }
        }

        protected string m_titre;
        public string Titre { get { return m_titre; } }
        #endregion
        #region Méthodes
        public void Ecrire(string pParoles)
        {
            StreamWriter objWrite = new StreamWriter(m_nomFichier);
            EcrireEntete(objWrite);
            EcrireParoles(objWrite, pParoles);
            objWrite.Close();

        }

        public abstract void EcrireEntete(StreamWriter pobjFichier);
        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);
        public abstract void LireEntete();
        public abstract string LireParoles(StreamReader pobjFichier);
        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
        }

        #endregion
        #region Constructeurs
        /// <summary>
        /// Initialise une instance de Chanson à 1 paramètre
        /// </summary>
        /// <param name="pNomFichier"></param>
        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
        }
        /// <summary>
        /// Initialise une instance de Chanson à 4 paramètres
        /// </summary>
        /// <param name="pRepertoire"></param>
        /// <param name="pArtiste"></param>
        /// <param name="pTitre"></param>
        /// <param name="pAnnée"></param>
        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnée)
        {
            m_nomFichier = pRepertoire + "\\" + pTitre + "." + Format.ToLower();
            m_artiste = pArtiste;
            m_titre = pTitre;
            m_annee = pAnnée;
        }

        #endregion
    }
}
