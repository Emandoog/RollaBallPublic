using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelRotation : MonoBehaviour
{
    private Coroutine corUp;
    private Coroutine corDown;
    private Coroutine CorHorizontalReverse;

    private Coroutine corLeft;
    private Coroutine corRight;
    private Coroutine CorVerticalReverse;

    private float RotationMaxoffset;
    private float MaxRotation = 5f;
    private float rotationOffSet = 0f;
   
    

    private float maxRotationTemp;
    private float desiredRotationX;
    private float desiredRotationZ;
    private float rotationSpeed = 0.008f;
    private float rotationPower = 0.09f;


    private void Start()
    {
        RotationMaxoffset = MaxRotation;
        maxRotationTemp = MaxRotation;
        RotationPowerUI.Instance.UpdateRotationPowerUI(RotationMaxoffset, 0, rotationOffSet);
    }

    private void FixedUpdate()
    {

       // transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
    }
    public void ScrollButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (context.ReadValue<float>() > 0)
            {
                rotationOffSet += 1;
                
            }
            if (context.ReadValue<float>() < 0)
            {
                rotationOffSet -= 1;
            }
            RotationPowerUI.Instance.UpdateRotationPowerUI(RotationMaxoffset,0, rotationOffSet);
            rotationOffSet =  Mathf.Clamp(rotationOffSet, 0, maxRotationTemp);
            MaxRotation = maxRotationTemp + rotationOffSet;
        }
    }



    public void RotateUP(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            if (CorHorizontalReverse != null) StopCoroutine(CorHorizontalReverse);
            corUp = StartCoroutine(ChangeRotationHorizontal());

        }
        else if (context.canceled)
        {
            if (CorHorizontalReverse != null) StopCoroutine(CorHorizontalReverse);
            if (corUp != null) StopCoroutine(corUp);
            CorHorizontalReverse = StartCoroutine(ReverseHorizontalRotation());

        }

    }
    public void RotateDown(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            if (CorHorizontalReverse != null) StopCoroutine(CorHorizontalReverse);
            corDown = StartCoroutine(ChangeRotationHorizontal(true));

        }
        else if (context.canceled)

        {
            if (CorHorizontalReverse != null) StopCoroutine(CorHorizontalReverse);
            if (corDown != null) StopCoroutine(corDown);
            CorHorizontalReverse = StartCoroutine(ReverseHorizontalRotation());

        }

    }
    public void RotateLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (CorVerticalReverse != null) StopCoroutine(CorVerticalReverse);
            corLeft = StartCoroutine(ChangeRotationVertical());

        }
        else if (context.canceled)
        {
            if (CorVerticalReverse != null) StopCoroutine(CorVerticalReverse);
            if (corLeft != null) StopCoroutine(corLeft);
            CorVerticalReverse = StartCoroutine(ReverseVerticalRotation());

        }

    }
    public void RotateRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (CorVerticalReverse != null) StopCoroutine(CorVerticalReverse);
            corRight = StartCoroutine(ChangeRotationVertical(true));

        }
        else if (context.canceled)
        {
            if (CorVerticalReverse != null) StopCoroutine(CorVerticalReverse);
            if (corRight != null) StopCoroutine(corRight);
            CorVerticalReverse = StartCoroutine(ReverseVerticalRotation());

        }

    }
    IEnumerator ChangeRotationHorizontal(bool reverse = false)
    {

        if (reverse)
        {

            while (desiredRotationX >= -MaxRotation)
            {
                
                desiredRotationX -= rotationPower;
                transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;

        }
        while (desiredRotationX <= MaxRotation)
        {
           
            desiredRotationX += rotationPower;
            transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
            yield return new WaitForSeconds(rotationSpeed);
        }
        yield break;
    }
    IEnumerator ReverseHorizontalRotation()
    {

        if (desiredRotationX > 0)
        {

            while (desiredRotationX >= 0)
            {
               
                desiredRotationX -= rotationPower;
                transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;


        }
        else if (desiredRotationX < 0)
        {
            while (desiredRotationX <= 0)
            {
              
                desiredRotationX += rotationPower;
                transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;

        }



    }
    IEnumerator ChangeRotationVertical(bool reverse = false)
    {

        if (reverse)
        {

            while (desiredRotationZ >= -MaxRotation)
            {
                desiredRotationZ -= rotationPower;
                transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;

        }
        while (desiredRotationZ <= MaxRotation)
        {
            desiredRotationZ += rotationPower;
            transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
            yield return new WaitForSeconds(rotationSpeed);
        }
        yield break;
    }
    IEnumerator ReverseVerticalRotation()
    {

        if (desiredRotationZ > 0)
        {

            while (desiredRotationZ >= 0)
            {
                desiredRotationZ -= rotationPower;
                transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;


        }
        else if (desiredRotationZ < 0)
        {
            while (desiredRotationZ <= 0)
            {
                desiredRotationZ += rotationPower;
                transform.rotation = Quaternion.Euler(new Vector3(desiredRotationX, 0, desiredRotationZ));
                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;

        }
    }
}
