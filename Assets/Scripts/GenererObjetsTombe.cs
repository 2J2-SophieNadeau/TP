using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererObjetsTombe : MonoBehaviour
{

    public GameObject grainCafeOriginal; //Objet GrainCafe qui sera dupliqué
    public GameObject somnifereOriginal; //Objet Somnifere qui sera dupliqué

    public AudioSource sonJeu; //Permet d'accélérer la musique de fond

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DupliquerGrainCafe", 1f);
        Invoke("DupliquerSomnifere", 0f);
    }

    // Fonction pour dupliquer le grain de café
    void DupliquerGrainCafe()
    {
        GameObject copieGrainCafe = Instantiate(grainCafeOriginal);
        copieGrainCafe.SetActive(true);
        copieGrainCafe.transform.position = new Vector3(Random.Range(-8.5f, 8.5f), 6f, 0f);


        // Permet d'incrémenter la fréquence de répétition du grain de café 
        if(ControlerTasse.pointage < 10)
        {
            Invoke("DupliquerGrainCafe", 2f);
        }
        else if (ControlerTasse.pointage >= 10 && ControlerTasse.pointage < 30)
        {
            Invoke("DupliquerGrainCafe", 1f);
            sonJeu.pitch = 1.2f;
        }
        else
        {
            Invoke("DupliquerGrainCafe", 0.5f);
            sonJeu.pitch = 1.5f;
        }
    }

    // Fonction pour dupliquer le somnifère
    void DupliquerSomnifere()
    {
        GameObject copieSomnifere = Instantiate(somnifereOriginal);
        copieSomnifere.SetActive(true);
        copieSomnifere.transform.position = new Vector3(Random.Range(-8.5f, 8.5f), 6f, 0f);

        // Permet d'incrémenter la fréquence de répétition du somnifère 
        if (ControlerTasse.pointage <= 10)
        {
            Invoke("DupliquerSomnifere", 2.5f);
        }
        else if (ControlerTasse.pointage > 10 && ControlerTasse.pointage < 30)
        {
            Invoke("DupliquerSomnifere", 1.5f);
        }
        else
        {
            Invoke("DupliquerSomnifere", 0.5f);
        }
    }
}