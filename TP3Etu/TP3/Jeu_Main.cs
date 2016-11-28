using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
  public partial class frm_Jeu_Main : Form
  {
    const int NB_LIGNE = 20;
    const int NB_COLONNE = 10;

    // Tableau contenant les types des cases
    TypeBloc[,] tableauDeType = new TypeBloc[NB_LIGNE, NB_COLONNE];

    // Tableaux contenant les positions courantes des blocs à placer
    int[] blocActifY = new int[4];
    int[] blocActifX = new int[4];

    // Taleaux contenant les positions courantes du bloc:
    int colonneCourante = 0;
    int ligneCourante = 0;

    enum TypeBloc
    {
      None,
      Gele,
      Carre,
      Ligne,
      T,
      J,
      L,
      S,
      Z
    }
    Color[] toutesLesCouleurs = new Color[9]
    {
      Color.Black,
      Color.Azure,
      Color.Green,
      Color.Orange,
      Color.Navy,
      Color.Red,
      Color.Peru, // "L"
      Color.Pink,
      Color.PeachPuff
    };


    public frm_Jeu_Main( )
    {
      InitializeComponent( );
    }

    #region Code fourni
    
    // Représentation visuelles du jeu en mémoire.
    PictureBox[,] toutesImagesVisuelles = null;
    
    
    /// <summary>
    /// L'événement de départ servant à l'initialisation de l'affichage et l'appel des fonctions.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmLoad( object sender, EventArgs e )
    {
      // Ne pas oublier de mettre en place les valeurs nécessaires à une partie.
      ExecuterTestsUnitaires();
      InitialiserSurfaceDeJeu(NB_LIGNE, NB_COLONNE);
    }

    /// <summary>
    /// Initialiser la surface du jeu en créant le tableau 2D servant de plateau de jeu.
    /// </summary>
    /// <param name="nbLignes">Nombre de lignes horizontales</param>
    /// <param name="nbCols">Nombre de lignes verticales</param>
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
      // **Fonction temporaire initialisant le tableau de Types à NONE:
      for (int i = 0; i < tableauDeType.GetLength(0); i++)
      {
        for (int j = 0; j < tableauDeType.GetLength(1); j++)
        {
          tableauDeType[i, j] = TypeBloc.None;
        }
      }
      // Test des formes **À CHANGER**
      AfficherCaree(blocActifY, blocActifX, colonneCourante, ligneCourante);
    }
    #endregion

    // Generer un carré: cette fonction sera modifiée...
    

    #region Samuel Masson
    // Fonction qui crée un carrée:
    void AfficherCaree(int[] blocActifY, int[] blocActifX, int positionY, int positionX)
    {
      // Pour un carrée, les pièces sont placées selon ceci:
      blocActifY[0] = 0 + positionY;
      blocActifY[1] = 0 + positionY;
      blocActifY[2] = 1 + positionY;
      blocActifY[3] = 1 + positionY;

      blocActifX[0] = 0 + positionX;
      blocActifX[1] = 1 + positionX;
      blocActifX[2] = 0 + positionX;
      blocActifX[3] = 1 + positionX;

      TypeBloc type = TypeBloc.Carre;

      AssignerTypes(blocActifY, blocActifX, positionY, positionX, type);

    }

    // Fonction qui crée un L:
    void AfficherL(int[] blocActifY, int[] blocActifX, int positionY, int positionX)
    {
      // Pour un L, les pièces sont placées selon ceci:
      blocActifY[0] = 0;
      blocActifY[1] = 1;
      blocActifY[2] = 2;
      blocActifY[3] = 2;

      blocActifX[0] = 0;
      blocActifX[1] = 0;
      blocActifX[2] = 0;
      blocActifX[3] = 1;

      TypeBloc type = TypeBloc.L;

      AssignerTypes(blocActifY, blocActifX, positionY, positionX, type);
    }

    //Fonction qui assigne les types de départ:
    void AssignerTypes(int[] blocActifY, int[] blocActifX, int positionY, int positionX, TypeBloc type)
    {
      for (int i = 0; i < blocActifY.Length; i++)
      {
        tableauDeType[blocActifY[i], blocActifX[i]] = type;
        toutesImagesVisuelles[blocActifY[i]+positionY, blocActifX[i]+positionX].BackColor = toutesLesCouleurs[(int)type];
      }
    }
    
    #endregion

    #region Anthony Sirois

    #endregion


    #region Tests Unitaires
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
