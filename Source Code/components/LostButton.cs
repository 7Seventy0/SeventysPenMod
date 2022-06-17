using UnityEngine;
using System.Collections;

public class LostButton : MonoBehaviour
{
    void Start()
    {
        gameObject.layer = 18;
    }


    void OnTriggerEnter(Collider collider)
    {
        FindObjectOfType<PenLogic>().transform.SetParent(null);
        FindObjectOfType<PenLogic>().transform.position = new Vector3(-63.921f, 12.624f, -85.498f);
    }
}