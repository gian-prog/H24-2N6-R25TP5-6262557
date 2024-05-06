using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonMP3 : Chanson
    {
        #region Propriétés

        public override string Format { get { return "mp3"; } }

        #endregion
        #region Méthodes
        public override void LireEntete()
        {
            StreamReader reader = new StreamReader(m_nomFichier);
            string[] tab = reader.ReadLine().Split('|');
            m_artiste = tab[2].Trim();
            m_titre = tab[0].Trim();
            m_annee = int.Parse(tab[1].Trim());
            reader.Close();

        }

        /// <summary>
        /// Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format MP3 et les retourne.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier</param>
        /// <returns></returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            string chaine = pobjFichier.ReadToEnd();
            return OutilsFormats.DecoderMP3(chaine);
        }
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            pobjFichier.WriteLine(OutilsFormats.EncoderMP3(pParoles));
        }
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine(Artiste + " | "  + Annee + " | " + Titre);
        }
        #endregion
        #region Constructeurs
        public ChansonMP3(string pNomFichier) : base(pNomFichier) { }

        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée) { }

        #endregion
    }
}
