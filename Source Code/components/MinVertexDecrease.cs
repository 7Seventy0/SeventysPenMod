using UnityEngine;
using System.Collections;

public class MinVertexDecrease : MonoBehaviour
{
    PenLogic penLogic;
    void Start()
    {
        gameObject.layer = 18;
        penLogic = FindObjectOfType<PenLogic>();
    }

    void OnTriggerEnter(Collider collider)
    {
        penLogic.minVertex -= 0.002f;
        GetComponent<AudioSource>().Play();
    }

}