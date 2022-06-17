using UnityEngine;
using System.Collections;

public class ColorPickableClass : MonoBehaviour
{
   public Color color;

     void Start()
    {
        gameObject.layer = 11;
        GetComponent<Renderer>().material.color = color;
    }

    public void UpdateColor()
    {
        
        GetComponent<Renderer>().material.color = color;
    }
}