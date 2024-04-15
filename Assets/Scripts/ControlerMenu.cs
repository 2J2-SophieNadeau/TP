using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerMenu : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuRegles;

    // Start is called before the first frame update
    void Start()
    {
        // Au commencement c'est le menu principal qui est affiché
        BoutonMenuPrincipal();
    }

    // Si le bouton Commencer est appuyé on lance la scene de jeu
    public void BoutonCommencer()
    {
        SceneManager.LoadScene(1);
    }

    // Si le bouton Règes du jeu est appuyé on affiche le menu de règles
    public void BoutonRegles()
    {
        menuPrincipal.SetActive(false);
        menuRegles.SetActive(true);
    }

    // Menu principal affiché au début, contrôle églament le bouton de retour dans le MenuRegles 
    public void BoutonMenuPrincipal()
    {
        menuPrincipal.SetActive(true);
        menuRegles.SetActive(false);
    }
}
