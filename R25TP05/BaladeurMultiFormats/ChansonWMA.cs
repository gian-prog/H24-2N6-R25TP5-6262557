using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonWMA : Chanson
    {
        #region Propriétés et Champs

        /// <summary>
        /// Le codage unique de la chanson
        /// </summary>
        private int m_codage;

        public override string Format { get { return "wma"; } }

        #endregion
        #region Méthodes
        public override void LireEntete()
        {
            StreamReader reader = new StreamReader(m_nomFichier);
            string[] tab = reader.ReadLine().Split('/');
            m_codage = int.Parse(tab[0]);
            m_artiste = tab[3].Trim();
            m_titre = tab[2].Trim();
            m_annee = int.Parse(tab[1].Trim());
        }

        /// <summary>
        /// Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format WMA et les retourne.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier</param>
        /// <returns></returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            string chaine = pobjFichier.ReadToEnd();
            return OutilsFormats.DecoderWMA(chaine, m_codage);
        }
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            Random random = new Random();
            int code = random.Next(3,15);
            pobjFichier.WriteLine(OutilsFormats.EncoderWMA(pParoles,code));
            pobjFichier.Close();
        }
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            Random random = new Random();
            int code = random.Next(3, 15);
            pobjFichier.WriteLine( code.ToString()+" / "+Annee.ToString()+" / "+Titre+" /   "+Artiste);
            pobjFichier.Close();
        }
        #endregion
        #region Constructeurs
        public ChansonWMA(string pNomFichier) : base(pNomFichier) { }

        public ChansonWMA(string pRepertoire, string pArtiste, string pTitre, int pAnnée) : base(pRepertoire, pArtiste, pTitre, pAnnée) { }

        #endregion
    }
}
