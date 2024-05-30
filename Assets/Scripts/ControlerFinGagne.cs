using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerFinGagne : MonoBehaviour
{
    public TextMeshProUGUI afficherMeilleurPointage;

    // Start is called before the first frame update
    void Start()
    {
        afficherMeilleurPointage.text = "Votre score: \n" + ControlerTasse.meilleurPointage;
        afficherMeilleurPointage.outlineWidth = 0.1f;
        afficherMeilleurPointage.outlineColor = new Color32(126, 90, 77, 170);
    }

    // Si le bouton Rejouer est appuyé on relance la scene de jeu
    public void Rejouer()
    {
        SceneManager.LoadScene(1);
        ControlerTasse.EffacerPointage(0);
    }
}
