using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    [SerializeField] private InputActionReference leftActivateAction; 
    [SerializeField] private InputActionReference rightActivateAction;

    private int lightState = 0;

    private Light lightComponent;
    public Color basicColor = Color.white;
    public Color UVColor = Color.blue;

    private void Start()
    {
        lightComponent = flashLight.GetComponent<Light>();
        flashLight.SetActive(false);
    }


    private void OnEnable()
    {
        if (leftActivateAction != null)
        {
            leftActivateAction.action.performed += GetOnLight;

        }
        
        if (rightActivateAction != null)
        {
            rightActivateAction.action.performed += GetOnLight;

        }
    }

    private void OnDisable()
    {
        if (leftActivateAction != null)
        {
            leftActivateAction.action.performed -= GetOnLight;
        }
        if (rightActivateAction != null)
        {
            rightActivateAction.action.performed -= GetOnLight;
        }
    }
    private void GetOnLight(InputAction.CallbackContext context)
    {
        if(lightState==0)
        {

            flashLight.SetActive(true);
            lightComponent.color = basicColor;
            lightState = 1;
        }
        else if(lightState==1)
        {
            lightComponent.color = UVColor;
            lightState = 2;
        }
        else if(lightState==2)
        {
            flashLight.SetActive(false);
            lightState = 0;
        }
    }
}
