using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetruireObjetsTombe : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        //On détruit l'objet si il touche le sol ou la tasse
        if (infoCollision.gameObject.name == "SolJeu" || infoCollision.gameObject.name == "Tasse")
        {
           Destroy(gameObject);
        }
    }
}
