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
      RotationAntihoraire
    }

    TypeBloc[,] tableauDeType = new TypeBloc[NB_LIGNE, NB_COLONNE];

    int[] blocActifY = new int[4] { 0, 0, 0, 0 };
    int[] blocActifX = new int[4] { 0, 0, 0, 0 };

    int ligneCourante = 0;
    int colonneCourante = 0;

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
      InitialiserTableau();
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

    #region Anthony Sirois

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

        default:
          return SensDeplacement.Bas;
      }
    }

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

    void DescendreBlocChaqueSeconde()
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
