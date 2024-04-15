using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerObjetsTombe : MonoBehaviour
{
    public float positionXMin;
    public float positionXMax;
    public float vitesseTombe;

    // Start is called before the first frame update
    void Start()
    {
        //Position initale en haut de la scene de façon aléatoire
        transform.position = new Vector2(Random.Range(positionXMin, positionXMax), 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * vitesseTombe * Time.deltaTime);

        if (transform.position.y <= -6f) {
            transform.position = new Vector2(Random.Range(positionXMin, positionXMax), 6f);
        }
    }

    void OnCollisionEnter2D(Collision2D infoCollision)
    {
       if(infoCollision.gameObject.name == "SolJeu" || infoCollision.gameObject.name == "Tasse")
        {
            transform.position = new Vector2(Random.Range(positionXMin, positionXMax), 6f);
        }
    }
}