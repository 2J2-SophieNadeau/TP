using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerFinPerd : MonoBehaviour
{
    public TextMeshProUGUI afficherPointage;
    public TextMeshProUGUI afficherMeilleurPointage;

    // Start is called before the first frame update
    void Start()
    {
        afficherPointage.text = "Votre score: \n" + ControlerTasse.pointage;
        afficherPointage.outlineWidth = 0.1f;
        afficherPointage.outlineColor = new Color32(126, 90, 77, 170);

        afficherMeilleurPointage.text = "Meilleur score: \n" + ControlerTasse.meilleurPointage;
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
