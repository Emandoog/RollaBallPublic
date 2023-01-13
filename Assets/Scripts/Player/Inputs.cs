using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
   
    [SerializeField] GameInputs gameInputs;

    private void Awake()
    {
        gameInputs = new GameInputs();


    }
    private void OnEnable()
    {
        gameInputs.GameMovement.ScrollPower.performed += GetComponent<LevelRotation>().ScrollButton;
        //gameInputs.GameMovement.ScrollPower.performed +=  RotationPowerUI.Instance.


        gameInputs.GameMovement.RotateUP.started += GetComponent<LevelRotation>().RotateUP;
        gameInputs.GameMovement.RotateUP.canceled += GetComponent<LevelRotation>().RotateUP;

        gameInputs.GameMovement.RotateDown.started += GetComponent<LevelRotation>().RotateDown;
        gameInputs.GameMovement.RotateDown.canceled += GetComponent<LevelRotation>().RotateDown;

        gameInputs.GameMovement.RotateLeft.started += GetComponent<LevelRotation>().RotateLeft;
        gameInputs.GameMovement.RotateLeft.canceled += GetComponent<LevelRotation>().RotateLeft;

        gameInputs.GameMovement.RotateRight.started += GetComponent<LevelRotation>().RotateRight;
        gameInputs.GameMovement.RotateRight.canceled += GetComponent<LevelRotation>().RotateRight;


        gameInputs.GameMovement.Enable();


    }
    private void OnDisable()
    {
        gameInputs.GameMovement.ScrollPower.performed -= GetComponent<LevelRotation>().ScrollButton;

        gameInputs.GameMovement.RotateUP.started -= GetComponent<LevelRotation>().RotateUP;
        gameInputs.GameMovement.RotateUP.canceled -= GetComponent<LevelRotation>().RotateUP;

        gameInputs.GameMovement.RotateDown.started -= GetComponent<LevelRotation>().RotateDown;
        gameInputs.GameMovement.RotateDown.canceled -= GetComponent<LevelRotation>().RotateDown;

        gameInputs.GameMovement.RotateLeft.started -= GetComponent<LevelRotation>().RotateLeft;
        gameInputs.GameMovement.RotateLeft.canceled -= GetComponent<LevelRotation>().RotateLeft;

        gameInputs.GameMovement.RotateRight.started -= GetComponent<LevelRotation>().RotateRight;
        gameInputs.GameMovement.RotateRight.canceled -= GetComponent<LevelRotation>().RotateRight;
        gameInputs.GameMovement.Disable();
    }

    
}

