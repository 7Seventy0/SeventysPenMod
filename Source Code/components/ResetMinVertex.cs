using UnityEngine;
using System.Collections;

public class ResetMinVertex : MonoBehaviour
{
    PenLogic penLogic;
    void Start()
    {
        gameObject.layer = 18;
        penLogic = FindObjectOfType<PenLogic>();
    }

    void OnTriggerEnter(Collider collider)
    {
        penLogic.minVertex = 0.01f;

    }

}