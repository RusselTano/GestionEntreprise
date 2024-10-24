
/*
    Programmeur:    Manuela,dylane,andreas,cedric
    Date:           octobre 2024
  
    Solution:       GestionEntreprise.sln
    Projet:         GestionEntreprise.csproj
    Classe:         GestionEntrepriseClassGenerale.cs  
  
    But:			creer une interface MDI        
  
    Traitement:	    Implementer le code
   			
    Sorties:		imprimer des controles
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ce = GestionEntreprise.GestionEntrepriseClassGenerale.Erreurs;
namespace GestionEntreprise
{
    internal class GestionEntrepriseClassGenerale
    {
        // Énumération des erreurs


        // Classe générale pour la gestion des erreurs et des méthodes partagées

        #region Enumeration

       
            public enum Erreurs
            {
            
            CEErreurIndeterminee,      // 2
            CEErreurOuverture,         // 3
            CEErreurEnregistrementSous, // 4
            CEErreurExtensionFichier,
            CEErreurExtensionDifferente,// 5
            CEErreurSauvegarde,        // 6
            CEErreurEnregistrement,
            CEErreurSelection,
            CEErreurPolice,
            CEErreurEdition,
            CEErreurStylePolice,
            CEErreurAlignement,
            CEErreurModification,
            CEMotIntrouvable,


        }

            #endregion

            #region Message d'erreur

            public static string[] tMessagesErreursStr = new string[15];
            public static void InitMessagesErreurs()
            {
            tMessagesErreursStr[(int)ce.CEErreurIndeterminee] = "Erreur indéterminée. Contactez la personne ressource.";
            tMessagesErreursStr[(int)ce.CEErreurOuverture] = "Erreur lors de l'ouverture : ";
            tMessagesErreursStr[(int)ce.CEErreurEnregistrementSous] = "Erreur lors de l'enregistrement sous : ";
            tMessagesErreursStr[(int)ce.CEErreurExtensionFichier] = "L'extension .RTF. doit etre utlilise";
            tMessagesErreursStr[(int)ce.CEErreurExtensionDifferente] = "Vous ne pouvez ouvrir que des fichiers portant  Llextension .RTF. avec l'application employes";
            tMessagesErreursStr[(int)ce.CEErreurSauvegarde] = "Erreur lors de la sauvegarde : ";
            tMessagesErreursStr[(int)ce.CEErreurEnregistrement] = "Erreur lors de l'enregistrement : ";
            tMessagesErreursStr[(int)ce.CEErreurSelection] = "\"Erreur lors de la modification de la sélection : \" ";
            tMessagesErreursStr[(int)ce.CEErreurPolice] = "Erreur lors de la modification de la police : ";
            tMessagesErreursStr[(int)ce.CEErreurAlignement] = "Erreur lors de la modification de l'alignement : ";
            tMessagesErreursStr[(int)ce.CEErreurEdition] = "Erreur lors de l'édition : ";
            tMessagesErreursStr[(int)ce.CEErreurStylePolice] = "Erreur lors de la modification du style de la police : ";
            tMessagesErreursStr[(int)ce.CEErreurModification] = " vous ne pouver pas ouvrir sans avoir apporter de modification : ";
            tMessagesErreursStr[(int)ce.CEMotIntrouvable] = "  : ";

        }

            #endregion

            #region Menu mutuellement exclusif

            
            
        public static void EnleverCrochetSousMenus(ToolStripMenuItem parentMenu)
        {
            if (parentMenu != null)
            {
                // Parcourir tous les sous-éléments du menu parent
                foreach (ToolStripItem item in parentMenu.DropDownItems)
                {
                    // Vérifier si l'élément est un ToolStripMenuItem
                    if (item is ToolStripMenuItem menuItem)
                    {
                        // Décocher cet élément
                        menuItem.Checked = false;
                    }
                }
            }
        }


        #endregion
    }

}
