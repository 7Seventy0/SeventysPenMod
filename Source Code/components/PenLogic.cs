using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using TMPro;
public class PenLogic : MonoBehaviour
{
    private readonly XRNode rNode = XRNode.RightHand;
    private readonly XRNode lNode = XRNode.LeftHand;
    bool rightTrigger;
    bool leftTrigger;
    bool rightsec;

    TrailRenderer trailRenderer;
    BoxCollider bc;
    Renderer pickerRenderer;

    PenGrabLogic penGrab;

    public float startWidth = 0.0031f;
    public float endWidth = 0.0031f;
    public float minVertex = 0.01f;

    TextMeshPro startWidthText;
    TextMeshPro endWidthText;
    TextMeshPro minvertexText;

    public Vector3 trpos;
    void Start()
    {
        
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        trailRenderer.minVertexDistance = 0.01f;
        trailRenderer.time = 99999;
        bc = GetComponentInChildren<BoxCollider>();
        bc.gameObject.AddComponent<ColorSwapper>();
        trpos = trailRenderer.transform.localPosition;
        pickerRenderer = bc.gameObject.GetComponent<Renderer>();
        
        penGrab = GetComponent<PenGrabLogic>();




        InvokeRepeating("SlowUpdate", 0, 0.1f);


    }
    float nextclear;
    float clearCooldown = 1;
    public void ChangeColor()
    {
      
        GameObject trTip = new GameObject("PenTip");
        trTip.transform.SetParent(transform);
        trTip.transform.localPosition = trpos;
        
        trTip.AddComponent<TrailRenderer>();
        trTip.GetComponent<TrailRenderer>().minVertexDistance = minVertex;
        trTip.GetComponent<TrailRenderer>().time = 999999;
       
        trTip.GetComponent<TrailRenderer>().endWidth = endWidth;
        trTip.GetComponent<TrailRenderer>().startWidth = startWidth;
        
        trailRenderer.transform.parent = null;
        
        trailRenderer = trTip.GetComponent<TrailRenderer>();
        
    }
    void Update()
    {
        InputDevices.GetDeviceAtXRNode(rNode).TryGetFeatureValue(CommonUsages.triggerButton, out rightTrigger);
        InputDevices.GetDeviceAtXRNode(lNode).TryGetFeatureValue(CommonUsages.triggerButton, out leftTrigger);
        if (penGrab.isInRightHand)
        {
            if (rightTrigger && !trailRenderer.emitting)
            {
                trailRenderer.emitting = true;
            }
            if (!rightTrigger && trailRenderer.emitting)
            {
                trailRenderer.emitting = false;
            }
        }
        else
        {
            if (leftTrigger && !trailRenderer.emitting)
            {
                trailRenderer.emitting = true;
            }
            if (!leftTrigger && trailRenderer.emitting)
            {
                trailRenderer.emitting = false;
            }
        }


        InputDevices.GetDeviceAtXRNode(rNode).TryGetFeatureValue(CommonUsages.secondaryButton, out rightsec);
        if (rightsec)
        { 
            if(Time.time > nextclear)
            {
                foreach(TrailRenderer tr in FindObjectsOfType<TrailRenderer>())
                {

                    tr.Clear();
                    if(trailRenderer.transform.parent == null)
                    {
                        Destroy(tr);
                    }
                    
                }
                nextclear = Time.time + clearCooldown;
            }
        }
    }
    void SlowUpdate()
    {

        if (startWidthText == null)
        {
            minvertexText = GameObject.Find("PENMINVERTEXDISTANCE").GetComponent<TextMeshPro>();
            startWidthText = GameObject.Find("PENSTARTWIDTHTEXT").GetComponent<TextMeshPro>();
            endWidthText = GameObject.Find("PENENDWIDTHTEXT").GetComponent<TextMeshPro>();
        }
        trailRenderer.material.color = pickerRenderer.material.color;
        trailRenderer.startWidth = startWidth;
        trailRenderer.endWidth = endWidth;
        trailRenderer.minVertexDistance = minVertex;

        minvertexText.text = "MIN VERTEX DISTANCE : " + minVertex;
        endWidthText.text = "PEN END WIDTH : " + endWidth;
        startWidthText.text = "PEN START WIDTH : " + startWidth;

    }
}