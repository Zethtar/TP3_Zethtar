using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
  public partial class frm_Jeu_Main : Form
  {
    public frm_Jeu_Main( )
    {
      InitializeComponent( );
    }

    #region Code fourni
    
    // Représentation visuelles du jeu en mémoire.
    PictureBox[,] toutesImagesVisuelles = null;
    
    /// <summary>
    /// Gestionnaire de l'événement se produisant lors du premier affichage 
    /// du formulaire principal.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmLoad( object sender, EventArgs e )
    {
      // Ne pas oublier de mettre en place les valeurs nécessaires à une partie.
      ExecuterTestsUnitaires();
      InitialiserSurfaceDeJeu(20,10);
    }

    private void InitialiserSurfaceDeJeu(int nbLignes, int nbCols)
    {
      // Création d'une surface de jeu 10 colonnes x 20 lignes
      toutesImagesVisuelles = new PictureBox[nbLignes, nbCols];
      tableauDeJeu.Controls.Clear();
      tableauDeJeu.ColumnCount = toutesImagesVisuelles.GetLength(1);
      tableauDeJeu.RowCount = toutesImagesVisuelles.GetLength(0);
      for (int i = 0; i < tableauDeJeu.RowCount; i++)
      {
        tableauDeJeu.RowStyles[i].Height = tableauDeJeu.Height / tableauDeJeu.RowCount;
        for (int j = 0; j < tableauDeJeu.ColumnCount; j++)
        {
          tableauDeJeu.ColumnStyles[j].Width = tableauDeJeu.Width / tableauDeJeu.ColumnCount;
          // Création dynamique des PictureBox qui contiendront les pièces de jeu
          PictureBox newPictureBox = new PictureBox();
          newPictureBox.Width = tableauDeJeu.Width / tableauDeJeu.ColumnCount;
          newPictureBox.Height = tableauDeJeu.Height / tableauDeJeu.RowCount;
          newPictureBox.BackColor = Color.Black;
          newPictureBox.Margin = new Padding(0, 0, 0, 0);
          newPictureBox.BorderStyle = BorderStyle.FixedSingle;
          newPictureBox.Dock = DockStyle.Fill;

          // Assignation de la représentation visuelle.
          toutesImagesVisuelles[i, j] = newPictureBox;
          // Ajout dynamique du PictureBox créé dans la grille de mise en forme.
          // A noter que l' "origine" du repère dans le tableau est en haut à gauche.
          tableauDeJeu.Controls.Add(newPictureBox, j, i);
        }
      }
    }
    #endregion





    #region Code à développer
    /// <summary>
    /// Faites ici les appels requis pour vos tests unitaires.
    /// </summary>
    void ExecuterTestsUnitaires()
    {      
      ExecuterTestABC();
      // A compléter...
    }

    // A renommer et commenter!
    void ExecuterTestABC()
    {
      // Mise en place des données du test
      
      // Exécuter de la méthode à tester
      
      // Validation des résultats
      
      // Clean-up
    }

    #endregion

  }








}
