using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
public class MoveControllerOverrideTest : MonoBehaviour
{
    [SerializeField]
    private InputActionReference activeSitAction;

    public Transform cam_Offset;
    public Transform cam_StartPos;
    public Transform cam_SitPos;
    private bool isSit = false;
    public Camera camera;
    XROrigin origin;
    private void Awake()
    {
        origin = GetComponent<XROrigin>();
    }

    private void Start()
    {   //카메라 offset을 제어해서 적용해보려고 했으나
        //카메라의 위치에 따라 CharacterController의 크기가 제어됨.
        // cam_Offset.position = cam_StartPos.position;

    }
    private void OnEnable()
    {
        activeSitAction.action.performed += SitDown;
        activeSitAction.action.performed += StandUp;
    }

    private void OnDisable()
    {
        activeSitAction.action.performed -= SitDown;
        activeSitAction.action.performed -= StandUp;
    }

    private void SitDown(InputAction.CallbackContext context)
    {
        float valuey = context.ReadValue<Vector2>().y;
        if (valuey < 0 && isSit == false)
        {
            cam_Offset.position = cam_SitPos.position;
            isSit = true;
        }
    }

    private void StandUp(InputAction.CallbackContext context)
    {
        float valuey = context.ReadValue<Vector2>().y;
        if (valuey > 0 && isSit)
        {
            cam_Offset.position = cam_StartPos.position;
            isSit = false;
        }
    }
}
