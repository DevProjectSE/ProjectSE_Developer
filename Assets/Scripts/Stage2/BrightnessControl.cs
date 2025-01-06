using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessControl : MonoBehaviour
{
    public GameObject light;
    public Light lightSource;
    public float targetIntensity;
    private float chageSpeed = 1.5f;

    private void OnTriggerExit(Collider ohter)
    {
        if (ohter.CompareTag("Player"))
        {
            StartCoroutine(ChangeBrightnessCoroutine());  
        }
    }

    private IEnumerator ChangeBrightnessCoroutine()
    { 
        float courrentIntensity = lightSource.intensity; 
        float elapsedTime = 0f;
        while(elapsedTime< chageSpeed)
        {
            lightSource.intensity = Mathf.Lerp(courrentIntensity,targetIntensity, elapsedTime / chageSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lightSource.intensity = targetIntensity;
    }
}
