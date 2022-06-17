using UnityEngine;
using System.Collections;

public class RandomColorClass : MonoBehaviour
{

    ColorPickableClass colorPickable;
    void Start()
    {
        
        colorPickable = gameObject.GetComponent<ColorPickableClass>();
        colorPickable.color = Random.ColorHSV(0f, Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        colorPickable.UpdateColor();
        InvokeRepeating("SlowUpdate",0,0.1f);
    }
  void OnTriggerEnter(Collider collider)
    {
        
        colorPickable.color = Random.ColorHSV(0f, Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        colorPickable.UpdateColor();
    }

    void SlowUpdate()
    {
        gameObject.layer = 18;
    }
}