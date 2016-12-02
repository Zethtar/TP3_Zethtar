using System;
using System.Drawing;
using System.Windows.Forms;
//Test, si je reste ça marche

namespace TP3
{
  public partial class frm_Jeu_Main : Form
  {
    const int NB_LIGNE = 20;
    const int NB_COLONNE = 10;

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

    enum SensDeplacement
    {
      Gauche,
      Droite,
      Bas,
      RotationHoraire,
      RotationAntihoraire,
      Saut,
      None
    }
    //None: juste pour le default
    //Saut : Descent le plus bas possible
    //RotationHoraire pas encore implanté; manque le bouton

    TypeBloc[,] tableauDeType = new TypeBloc[NB_LIGNE, NB_COLONNE];

    int[] blocActifY = new int[4] { 0, 0, 0, 0 };
    int[] blocActifX = new int[4] { 0, 0, 0, 0 };

    int ligneCourante = 0;
    int colonneCourante = 0;

    Color[] toutesLesCouleurs = new Color[9]
{
      Color.Black,
      Color.Azure,
      Color.Green, // Carre
      Color.Orange,
      Color.Navy,
      Color.Red,
      Color.Peru, // "L"
      Color.YellowGreen, // "S"
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
    /// Gestionnaire de l'événement se produisant lors du premier affichage 
    /// du formulaire principal.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmLoad( object sender, EventArgs e )
    {
      // Ne pas oublier de mettre en place les valeurs nécessaires à une partie.
      ExecuterTestsUnitaires();
      InitialiserSurfaceDeJeu(NB_LIGNE, NB_COLONNE);
      InitialiserTableau();

      //CHANGE
      AfficherFinDePartie();
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

    #region Samuel Masson

    // Fonction qui crée un carré:
    void AfficherCarre(int[] blocActifY, int[] blocActifX, int positionY, int positionX)
    {
      // Pour un carré, les pièces sont placées selon ceci:
      blocActifY[0] = 0;
      blocActifY[1] = 0;
      blocActifY[2] = 1;
      blocActifY[3] = 1;

      blocActifX[0] = 0;
      blocActifX[1] = 1;
      blocActifX[2] = 0;
      blocActifX[3] = 1;

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

    // Fonction qui crée un S:
    void AfficherS(int[] blocActifY, int[] blocActifX, int positionY, int positionX)
    {
      // Pour un S, les pièces sont placées selon ceci:
      blocActifY[0] = 0;
      blocActifY[1] = 1;
      blocActifY[2] = 1;
      blocActifY[3] = 2;

      blocActifX[0] = 0;
      blocActifX[1] = 0;
      blocActifX[2] = 1;
      blocActifX[3] = 1;

      TypeBloc type = TypeBloc.S;

      AssignerTypes(blocActifY, blocActifX, positionY, positionX, type);
    }

    // Fonction qui crée un T:
    void AfficherT(int[] blocActifY, int[] blocActifX, int positionY, int positionX)
    {
      // Pour un T, les pièces sont placées selon ceci:
      blocActifY[0] = 0;
      blocActifY[1] = 1;
      blocActifY[2] = 1;
      blocActifY[3] = 2;

      blocActifX[0] = 0;
      blocActifX[1] = 0;
      blocActifX[2] = 1;
      blocActifX[3] = 1;

      TypeBloc type = TypeBloc.S;

      AssignerTypes(blocActifY, blocActifX, positionY, positionX, type);
    }

    //Fonction qui assigne les types de départ:
    void AssignerTypes(int[] blocActifY, int[] blocActifX, int positionY, int positionX, TypeBloc type)
    {
      for (int i = 0; i < blocActifY.Length; i++)
      {
        tableauDeType[blocActifY[i], blocActifX[i]] = type;
        toutesImagesVisuelles[blocActifY[i] + positionY, blocActifX[i] + positionX].BackColor = toutesLesCouleurs[(int)type];
      }
    }

    #endregion

    #region Anthony Sirois

    /// <summary>
    /// Lis le mouvement que le joueur veut effectuer
    /// </summary>
    /// <returns>Retourne le sens de deplacement (Type: SensDeplacement)</returns>
    SensDeplacement SaisirDeplacementJoueur()
    {
      ConsoleKey inputDuJoueur = Console.ReadKey().Key;

      switch (inputDuJoueur)
      {
        case ConsoleKey.LeftArrow:
          return SensDeplacement.Gauche;

        case ConsoleKey.RightArrow:
          return SensDeplacement.Droite;

        case ConsoleKey.DownArrow:
          return SensDeplacement.Bas;

        case ConsoleKey.UpArrow:
          return SensDeplacement.RotationAntihoraire;

        //case ConsoleKey. :
        //  return SensDeplacement.RotationHoraire;

        case ConsoleKey.Spacebar:
          return SensDeplacement.Saut;

        default:
          return SensDeplacement.None;
      }
    }

    /// <summary>
    /// Détermine si le bloc peut bouger; si il y a un bloc qui limite son mouvement ou qu'il est à la limite du tableau de jeu
    /// </summary>
    /// <param name="sens">Sens du déplacement du joueur déterminé par la fonction SaisirDeplacementJoueur</param>
    /// <returns>Retourne un booléen (vrai si le joueur peut bouger)</returns>
    bool BlocPeutBouger(SensDeplacement sens)
    {
      bool blocPeutBouger = true;
      InitialiserTableau();
      if (sens == SensDeplacement.Gauche)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          if (tableauDeType[blocActifY[i], blocActifX[i] + colonneCourante - 1] == TypeBloc.Gele || tableauDeType[blocActifY[i], blocActifX[i] + colonneCourante - 1] == 0)
          {
            blocPeutBouger = false;
          }
        }
      }
      else if (sens == SensDeplacement.Droite)
      {
        for (int i = 0; i < tableauDeType.Length; i++)
        {
          if ((tableauDeType[blocActifY[i], blocActifX[i] + colonneCourante + 1] + colonneCourante + 1 == TypeBloc.Gele) || (blocActifX[i] + colonneCourante + 1 == NB_COLONNE - 1))
          {
            blocPeutBouger = false;
          }
        }
      }
      else if (sens == SensDeplacement.Bas)
      {
        for (int i = 0; i < tableauDeType.Length; i++)
        {
          if (tableauDeType[blocActifY[i] + ligneCourante + 1, blocActifX[i]] == TypeBloc.Gele || blocActifX[i] + ligneCourante + 1 == 0)
          {
            blocPeutBouger = false;
          }
        }
      }
      else if (sens == SensDeplacement.RotationAntihoraire)
      {
        for (int i = 0; i < tableauDeType.Length; i++)
        {
          if (tableauDeType[blocActifX[i], -blocActifY[i] + colonneCourante] == TypeBloc.Gele || -blocActifY[i] + colonneCourante <= 0)
          {
            blocPeutBouger = false;
          }
        }
      }
      else if (sens == SensDeplacement.RotationHoraire)
      {
        for (int i = 0; i < tableauDeType.Length; i++)
        {
          if (tableauDeType[-blocActifX[i], blocActifY[i] + colonneCourante] == TypeBloc.Gele || blocActifX[i] + colonneCourante + 1 == 0)
          {
            blocPeutBouger = false;
          }
        }
      }
      return blocPeutBouger;
    }

    /// <summary>
    /// Déplace le bloc dans le tableau dans la direction que le joueur veut
    /// </summary>
    /// <param name="sens">Sens du déplacement du joueur déterminé par la fonction SaisirDeplacementJoueur</param>
    void DeplacerBloc(SensDeplacement sens)
    {
    if (BlocPeutBouger(SaisirDeplacementJoueur()))
    {
        switch (sens)
        {
          case SensDeplacement.Gauche:
            colonneCourante -= 1;
            break;

          case SensDeplacement.Droite:
            colonneCourante += 1;
            break;

          case SensDeplacement.Bas:
            ligneCourante += 1;
            break;

          case SensDeplacement.RotationAntihoraire:
            for (int i = 0; i < blocActifY.Length; i++)
            {
              blocActifX[i] = blocActifY[i];
              blocActifY[i] = -blocActifX[i];
            }
            break;

          case SensDeplacement.RotationHoraire:
            for (int i = 0; i < blocActifY.Length; i++)
            {
              blocActifX[i] = -blocActifY[i];
              blocActifY[i] = blocActifX[i];
            }
            break;

          default:
            ligneCourante += 1;
            break;
        }
      }
    }

    /// <summary>
    /// Analyse s'il y a un bloc à l'emplacement du prochain bloc
    /// </summary>
    /// <returns>Booléen qui est vrai si la partie est terminé sinon il est faux</returns>
    bool DetecterFinDePartie()
    {
      bool partieEstTerminee = false;

      for (int i = 0; i < 4; i++)
      {
        if (tableauDeType[blocActifY[i], blocActifX[i]+colonneCourante] != TypeBloc.None)
        {
          partieEstTerminee = true;
        }
      }
      return partieEstTerminee;
    }

    /// <summary>
    /// Affiche une message box annonçant la fin de partie et lorsque le joueur appuie sur OK
    /// les statistiques apparaissent
    /// </summary>
    void AfficherFinDePartie()
    {
      DialogResult result = MessageBox.Show("La partie est terminée",
                      "Fin de partie",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
      if (result == DialogResult.OK)
      {
        Statistique statistique = new Statistique();
        statistique.ShowDialog();
      }
    }


    /// <summary>
    /// Rempli le tableau de TypeBloc.None
    /// </summary>
    void InitialiserTableau()
    {
      for (int i = 0; i < NB_LIGNE - 1; i++)
      {
        for (int j = 0; j < NB_COLONNE - 1; j++)
        {
          tableauDeType[i, j] = TypeBloc.None;
        }
      }
    }

    /// <summary>
    /// Actionne le compteur et spécifi ses conditions
    /// </summary>
    void ActiverDescenteAutomatique()
    {
      Timer timerRefresh = new Timer();
      timerRefresh.Tick += new EventHandler(timerRefresh_Tick);
      timerRefresh.Interval = 1000;
      timerRefresh.Start();
    }

    #endregion

    private void timerRefresh_Tick(object sender, EventArgs e)
    {
      DeplacerBloc(SensDeplacement.Bas);
    }
  }







}
