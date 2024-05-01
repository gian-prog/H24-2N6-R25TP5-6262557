using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public interface IBaladeur
    {
        #region Propriétés
        /// <summary>
        /// Obtient le nombre de chansons.
        /// </summary>
        int NbChansons { get; }

        #endregion
        #region Méthodes
        /// <summary>
        /// Affiche la liste des chansons dans la pListView passée en paramètre.
        /// </summary>
        /// <param name="pListView"></param>
        void AfficherLesChansons(ListView pListView);

        /// <summary>
        /// Obtient la chanson à l’index pIndex passé en paramètre.
        /// </summary>
        /// <param name="pIndex">index de la chanson</param>
        /// <returns></returns>
        Chanson ChansonAt(int pIndex);

        /// <summary>
        /// Récupère la liste des fichiers dans le dossier Chansons, instancie selon le cas des objets des classes dérivées de la classe Chanson.
        /// </summary>
        void ConstruireLaListeDesChansons();

        /// <summary>
        /// Converti le format de la chanson vers AAC
        /// </summary>
        /// <param name="pIndex">index de la chanson</param>
        void ConvertirVersAAC(int pIndex);

        /// <summary>
        /// Converti le format de la chanson vers MP3
        /// </summary>
        /// <param name="pIndex">index de la chanson</param>
        void ConvertirVersMP3(int pIndex);

        /// <summary>
        /// Converti le format de la chanson vers WMA
        /// </summary>
        /// <param name="pIndex"></param>
        void ConvertirVersWMA(int pIndex);


        #endregion
    }
}
