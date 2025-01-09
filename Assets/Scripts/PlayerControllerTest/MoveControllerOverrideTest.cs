using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Readers;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;

public class MoveControllerOverrideTest : MonoBehaviour
{
    [SerializeField]
    private InputActionReference activeAction;
    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        activeAction.action.performed += SitDown;
    }

    private void OnDisable()
    {
        activeAction.action.performed -= SitDown;
    }

    private void SitDown(InputAction.CallbackContext context)
    {
        float valuey = context.ReadValue<Vector2>().y;
        if (valuey < 0)
        {
            Debug.Log("앉으라 ");
            cc.height = 0.45f;
        }
    }
}
