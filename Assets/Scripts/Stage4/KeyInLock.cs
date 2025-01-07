using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class KeyInLock : MonoBehaviour
{

    private XRKnob knob;
    public Transform openHint;
    public GameObject upperPart;
    private void Awake()
    {
        knob = GetComponent<XRKnob>();
    }

    public void OnActive()
    {
        if (knob.value >= 0.01f)
        {
            upperPart.transform.position = openHint.position;
        }
        Debug.Log($"knob val : {knob.value}");
    }
}
