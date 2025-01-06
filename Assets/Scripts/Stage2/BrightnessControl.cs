using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessControl : MonoBehaviour
{
    public GameObject light;
    public Light lightSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            print("Ãæµ¹ÇÔ");

        }
    }

}
