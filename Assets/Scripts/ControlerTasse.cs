using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlerTasse : MonoBehaviour
{
    public float vitesseX;
    public float vitesseXMax;
    public float vitesseY;
    public float positionXMin;
    public float positionXMax;

    public AudioClip sonCafe;
    public AudioClip sonSomnifere;
    public AudioClip sonVitesse;

    public GameObject vie1;
    public GameObject vie2;
    public GameObject vie3;

    public bool partieTerminee = false;

    public TextMeshProUGUI compteur;
    public static int pointage;
    public static int nbVies;
    public static int meilleurPointage;

    public static void EffacerPointage(int nouveauPointage)
    {
        pointage = nouveauPointage;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Gestion du nombre de vies; au départ il y a 3 vies
        nbVies = 3;

        vie1.SetActive(true);
        vie2.SetActive(true);
        vie3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(partieTerminee == false)
        {
            // Déplacement vers la gauche
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
            {
                vitesseX = -vitesseXMax;

                //Gestion de l'animation de marche vers la gauche
                GetComponent<Animator>().SetBool("marcheGauche", true);
                GetComponent<Animator>().SetBool("marcheDroite", false);
                GetComponent<Animator>().SetBool("arret", false);
            }

            // Déplacement vers la droite
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
            {
                vitesseX = vitesseXMax;

                //Gestion de l'animation de marche vers la droite
                GetComponent<Animator>().SetBool("marcheDroite", true);
                GetComponent<Animator>().SetBool("marcheGauche", false);
                GetComponent<Animator>().SetBool("arret", false);
            }

            else
            {
                vitesseX = GetComponent<Rigidbody2D>().velocity.x;

                //Gestion des animations d'arrêt à gauche et à droite
                GetComponent<Animator>().SetBool("marcheGauche", false);
                GetComponent<Animator>().SetBool("marcheDroite", false);
                GetComponent<Animator>().SetBool("arret", true);
            }

            //Permet d'appliquer les vitesses en X et Y
            GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);


            //Lorsque la tasse sort de la scène, elle est ramenée du côté opposé
            if (transform.position.x < positionXMin)
            {
                transform.position = new Vector2(positionXMax, transform.position.y);
            }
            else if (transform.position.x > positionXMax)
            {
                transform.position = new Vector2(positionXMin, transform.position.y);
            }
        }
    }


    //Détection des collisions pour la tasse
    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        //Collision avec un grain de café
        if (infoCollision.gameObject.tag == "Grain Cafe")
        {
            // On incrémente le pointage
            pointage++;

            //le meilleur pointage est calculé selon le pointage actuel
            if(pointage > meilleurPointage)
            {
                meilleurPointage = pointage;
            }

            compteur.text = "Score: " + pointage.ToString();
            GetComponent<AudioSource>().PlayOneShot(sonCafe);

            //Son qui appuie l'accélération de la répétition des objets
            if (pointage == 10)
            {
                GetComponent<AudioSource>().PlayOneShot(sonVitesse);
            }
            if (pointage == 30)
            {
                GetComponent<AudioSource>().PlayOneShot(sonVitesse);
            }
        }

        //Collision avec un somnifère
        if (infoCollision.gameObject.tag == "Somnifere")
        {
            GetComponent<AudioSource>().PlayOneShot(sonSomnifere);

            //Gestion du nombre de vies
            if(nbVies == 3)
            {
                vie1.SetActive(true);
                vie2.SetActive(true);
                vie3.SetActive(false);
                nbVies = 2;
            }
            else if (nbVies == 2)
            {
                vie1.SetActive(true);
                vie2.SetActive(false);
                vie3.SetActive(false);
                nbVies = 1;
            }
            else {
                vie1.SetActive(false);
                vie2.SetActive(false);
                vie3.SetActive(false);
                nbVies = 0;

                partieTerminee = true;

                // On charge la scène corespondante selon le pointage
                if (pointage >= meilleurPointage)
                {
                    SceneManager.LoadScene("FinGagne");
                } else if (pointage < meilleurPointage)
                {
                    SceneManager.LoadScene("FinPerd");
                }
            }
        }
    }

    
}
