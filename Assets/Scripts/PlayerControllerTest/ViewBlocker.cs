using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBlocker : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("하이");
    }
}
