using UnityEngine;
using System.Collections;

public class ColorSwapper : MonoBehaviour
{
    
    void Start()
    {
        gameObject.layer = 11;
    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<ColorPickableClass>() != null)
        {
            gameObject.GetComponent<Renderer>().material.color = collider.GetComponent<ColorPickableClass>().color;
            GameObject.FindObjectOfType<PenLogic>().ChangeColor();

            GetComponent<AudioSource>().pitch  = Random.Range(0.5f,1.5f);
            GetComponent<AudioSource>().Play();

        }
    }
}