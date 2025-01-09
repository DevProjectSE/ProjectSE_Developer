using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
public class CustomPlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference activeSitAction;
    [SerializeField]
    private InputActionReference activePrimaryX;
    private CharacterController CC;
    public Transform cam_Offset;
    public Transform cam_StartPos;
    public Transform cam_SitPos;
    private bool isSit = false;

    private void Start()
    {   //카메라 offset을 제어해서 적용해보려고 했으나
        //카메라의 위치에 따라 CharacterController의 크기가 제어됨.
        // cam_Offset.position = cam_StartPos.position;
        CC = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        activeSitAction.action.performed += SitDown;
        activeSitAction.action.performed += StandUp;
        // activePrimaryX.action.performed += Primary;

    }

    private void OnDisable()
    {
        activeSitAction.action.performed -= SitDown;
        activeSitAction.action.performed -= StandUp;
        // activePrimaryX.action.performed -= Primary;

    }

    private void Primary(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log("하이");
    }

    private void SitDown(InputAction.CallbackContext context)
    {
        float valuey = context.ReadValue<Vector2>().y;
        if (valuey < 0 && isSit == false)
        {
            cam_Offset.position = cam_SitPos.position;
            CC.height = cam_SitPos.position.y;
            isSit = true;
        }
    }

    private void StandUp(InputAction.CallbackContext context)
    {
        float valuey = context.ReadValue<Vector2>().y;
        if (valuey > 0 && isSit)
        {
            cam_Offset.position = cam_StartPos.position;
            CC.height = cam_StartPos.position.y;
            isSit = false;
        }
    }
}
