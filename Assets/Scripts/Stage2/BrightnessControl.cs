using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class BrightnessControl : MonoBehaviour
{
    public GameObject light;
    public Light lightSource;
    public float targetIntensity;
    public float targetAngle;
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
        float currentAngle = lightSource.transform.rotation.eulerAngles.x;
        float elapsedTime = 0f;
        while(elapsedTime< chageSpeed)
        {
            lightSource.intensity = Mathf.Lerp(courrentIntensity,targetIntensity, elapsedTime / chageSpeed);
            float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, elapsedTime / chageSpeed);
            lightSource.transform.rotation = Quaternion.Euler(newAngle, 0, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lightSource.intensity = targetIntensity;
        lightSource.transform.rotation = Quaternion.Euler(targetAngle, 0, 0);
     
    }
}
