using UnityEngine;
using System.Collections;

public class StartWidthDecrease : MonoBehaviour
{
    PenLogic penLogic;
    void Start()
    {
        gameObject.layer = 18;
        penLogic = FindObjectOfType<PenLogic>();
    }

    void OnTriggerEnter(Collider collider)
    {
        penLogic.startWidth -= 0.001f;
        GetComponent<AudioSource>().Play();

    }

}