using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonAAC : Chanson
    {
        #region Propriétés

        public override string Format { get { return "aac"; } }

        #endregion
        #region Méthodes
        public override void LireEntete()
        {
            StreamReader reader = new StreamReader(m_nomFichier);
            string[] tab = reader.ReadLine().Split(':');
            string[] tabtitre = tab[0].Split('=');
            string[] tabArtiste = tab[1].Split('=');
            string[] tabAnnee = tab[2].Split('=');
            m_artiste = tabArtiste[1].Trim();
            m_titre = tabtitre[1].Trim();
            m_annee = int.Parse(tabAnnee[1].Trim());
        }

        /// <summary>
        /// Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format AAC et les retourne.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier</param>
        /// <returns></returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            string chaine = pobjFichier.ReadToEnd();
            return OutilsFormats.DecoderAAC(chaine);
        }
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderAAC(pParoles));
            pobjFichier.Close();
        }
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine("TITRE = " + Titre + " : ARTISTE = " + Artiste + " : ANNÉE = " + Annee);
            pobjFichier.Close();
        }
        #endregion
        #region Constructeurs
        public ChansonAAC(string pNomFichier) : base(pNomFichier) { }

        public ChansonAAC(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée) { }

        #endregion
    }
}
