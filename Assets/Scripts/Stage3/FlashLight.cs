using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    private InputActionReference activateAction; 

    private void Start()
    {
        flashLight.SetActive(false);
    }


    private void OnEnable()
    {
        if (activateAction != null) ;
        {
            activateAction.action.performed += GetOnLight;

        }
    }

    private void OnDisable()
    {
        // �̺�Ʈ ���� ����
        if (activateAction != null)
        {
            activateAction.action.performed -= GetOnLight;
        }
    }
    private void GetOnLight(InputAction.CallbackContext context)
    {
        if(flashLight !=null)
        {
            flashLight.SetActive(true);
        }
    }
}
