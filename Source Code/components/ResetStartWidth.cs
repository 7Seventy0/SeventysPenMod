using UnityEngine;
using System.Collections;

public class ResetEndWidth : MonoBehaviour
{
    PenLogic penLogic;
    void Start()
    {
        gameObject.layer = 18;
        penLogic = FindObjectOfType<PenLogic>();
    }

    void OnTriggerEnter(Collider collider)
    {
        penLogic.endWidth = 0.0031f;

    }

}