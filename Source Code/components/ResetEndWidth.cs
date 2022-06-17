using UnityEngine;
using System.Collections;

public class ResetStartWidth : MonoBehaviour
{
    PenLogic penLogic;
    void Start()
    {
        gameObject.layer = 18;
        penLogic = FindObjectOfType<PenLogic>();
    }

    void OnTriggerEnter(Collider collider)
    {
        penLogic.startWidth = 0.0031f;

    }

}