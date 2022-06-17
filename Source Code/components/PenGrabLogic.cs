using UnityEngine;
using System.Collections;
using UnityEngine.XR;

public class PenGrabLogic : MonoBehaviour
{
    private readonly XRNode rNode = XRNode.RightHand;
    private readonly XRNode lNode = XRNode.LeftHand;
    bool gripr;
    bool gripl;
    bool isHolding;
    public bool isInRightHand;



    void Start()
    {
        gameObject.layer = 18;

    }
    void Update()
    {
        if(transform.parent == null)
        {
            isHolding = false;
        }
        InputDevices.GetDeviceAtXRNode(rNode).TryGetFeatureValue(CommonUsages.gripButton, out gripr);
        InputDevices.GetDeviceAtXRNode(lNode).TryGetFeatureValue(CommonUsages.gripButton, out gripl);
    }

    float nextgrab;
    float grabcooldown = 0.2f;
    void OnTriggerStay(Collider other)
    {
        if(Time.time > nextgrab)
        {
            if (other.name == "RightHandTriggerCollider")
            {
                if (gripr)
                {
                    if (!isHolding)
                    {
                        transform.SetParent(GameObject.Find("palm.01.R").transform);
                        isHolding = true;
                        isInRightHand = true;
                    }
                    else
                    {
                        transform.parent = null;
                    }
                    nextgrab = Time.time + grabcooldown;
                }
            }

            if (other.name == "LeftHandTriggerCollider")
            {
                if (gripl)
                {
                    if (!isHolding)
                    {
                        transform.SetParent(GameObject.Find("palm.01.L").transform);
                        isHolding = true;
                        isInRightHand = false;
                        
                    }
                    else
                    {
                        transform.parent = null;
                    }
                    nextgrab = Time.time + grabcooldown;
                }
            }
        }
    }
}