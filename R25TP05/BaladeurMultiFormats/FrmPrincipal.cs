using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Server;

namespace BaladeurMultiFormats
{
    // Étapes de  réalisation :
    // Étape #1 : Définir les classes Chanson et ChasonAAC

    public partial class FrmPrincipal : Form
    {
        public const string APP_INFO = "6262557";

        #region Propriété : MonHistorique
        public Historique MonHistorique { get; }
        #endregion
        //---------------------------------------------------------------------------------
        #region FrmPrincipal
        Baladeur baladeur = new Baladeur();
        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;
            MonHistorique = new Historique();
            // À COMPLÉTER...

            //Tests
            //ChansonAAC chansonAAC = new ChansonAAC("Chansons\\Blame it on me.aac") ;
            //ChansonMP3 chansonMP3 = new ChansonMP3("Chansons\\Billie Jean.mp3");
            //ChansonWMA chansonWMA = new ChansonWMA("Chansons\\Hotel California.wma");
            baladeur.ConstruireLaListeDesChansons();
            baladeur.AfficherLesChansons(lsvChansons);
            lblNbChansons.Text = baladeur.NbChansons.ToString();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            // À COMPLÉTER...
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                switch (baladeur.ChansonAt(lsvChansons.SelectedIndices[0]).Format.ToLower())
                {
                    case "aac":
                        MnuFormatConvertirVersAAC.Enabled = false;
                        MnuFormatConvertirVersMP3.Enabled = true;
                        MnuFormatConvertirVersWMA.Enabled = true;
                        break;

                    case "mp3":
                        MnuFormatConvertirVersAAC.Enabled = true;
                        MnuFormatConvertirVersMP3.Enabled = false;
                        MnuFormatConvertirVersWMA.Enabled = true;

                        break;

                    case "wma":
                        MnuFormatConvertirVersAAC.Enabled = true;
                        MnuFormatConvertirVersMP3.Enabled = true;
                        MnuFormatConvertirVersWMA.Enabled = false;

                        break;
                }
            }
            
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
            MettreAJourSelonContexte();
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                txtParoles.Text = baladeur.ChansonAt(lsvChansons.SelectedIndices[0]).Paroles;
                Consultation consultation = new Consultation(DateTime.Now, baladeur.ChansonAt(lsvChansons.SelectedIndices[0]));
                MonHistorique.Add(consultation);
            }

        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
           
            MonHistorique.Clear();
            baladeur.ConvertirVersAAC(lsvChansons.SelectedIndices[0]);
            baladeur.AfficherLesChansons(lsvChansons);

        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();
            baladeur.ConvertirVersMP3(lsvChansons.SelectedIndices[0]);
            baladeur.AfficherLesChansons(lsvChansons);


        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
            MonHistorique.Clear();
            baladeur.ConvertirVersWMA(lsvChansons.SelectedIndices[0]);
            baladeur.AfficherLesChansons(lsvChansons);


        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Historique
        private void MnuSpécialHistorique_Click(object sender, EventArgs e)
        {
            FrmHistorique objFormulaire = new FrmHistorique(MonHistorique);
            objFormulaire.ShowDialog();
        }
        #endregion
         //---------------------------------------------------------------------------------
        #region Méthodes : MnuFichierQuitter_Click
        //---------------------------------------------------------------------------------
        private void MnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
