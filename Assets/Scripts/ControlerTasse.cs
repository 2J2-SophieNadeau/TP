using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerTasse : MonoBehaviour
{
    public float vitesseX;
    public float vitesseXMax;
    public float vitesseY;
    public float positionXMin;
    public float positionXMax;

    public AudioClip sonCafe;
    public AudioClip sonSomnifere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacement vers la gauche
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vitesseX = -vitesseXMax;
        }

        // Déplacement vers la droite
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vitesseX = vitesseXMax;
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;
        }

        //Permet d'appliquer les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);


        //Lorsque la tasse sort de la scène, elle est ramenée au côté opposé
        if (transform.position.x < positionXMin)
        {
            transform.position = new Vector2(positionXMax, transform.position.y);
        }
        else if (transform.position.x > positionXMax)
        {
            transform.position = new Vector2(positionXMin, transform.position.y);
        }
    }


    //Détection des collisions pour la tasse
    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        //Collision avec un grain de café
        if(infoCollision.gameObject.name == "GrainCafe")
        {
            GetComponent<AudioSource>().PlayOneShot(sonCafe);
        }
        //Collision avec un somnifère
        else if (infoCollision.gameObject.name == "Somnifere")
        {
            GetComponent<AudioSource>().PlayOneShot(sonSomnifere);
        }
    }
}
