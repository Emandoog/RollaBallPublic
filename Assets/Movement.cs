using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] GameInputs gameInputs;
    public GameObject Pointer;
    private InputAction input;
    public float Power = 5;
    private float rotateUp;
    public float rotationPower= 0.1f;
    public float desiredRotationX;
    public float desiredRotationZ;

   
    private Coroutine corUp;
    private Coroutine corDown;
    private Coroutine CorHorizontalReverse;

    private Coroutine corLeft;
    private Coroutine corRight;
    private Coroutine CorVerticalReverse;

    public  float MaxRotation = 4f;
    public float rotationSpeed = 0.005f;

    // private float desiredRotationX;
    private float rotateDown;
    private void Awake()
    {
        gameInputs = new GameInputs();
       
      
    }
    private void OnEnable()
    {
      
        gameInputs.GameMovement.RotateUP.started += RotateUP;
        gameInputs.GameMovement.RotateUP.canceled += RotateUP;

        gameInputs.GameMovement.RotateDown.started += RotateDown;
        gameInputs.GameMovement.RotateDown.canceled += RotateDown;

        gameInputs.GameMovement.RotateLeft.started += RotateLeft;
        gameInputs.GameMovement.RotateLeft.canceled +=RotateLeft;

        gameInputs.GameMovement.RotateRight.started += RotateRight;
        gameInputs.GameMovement.RotateRight.canceled += RotateRight;


        gameInputs.GameMovement.Enable();

        // mainMenuInputs.MainMenuKeyboard.EnemyClick.performed += Panic;
    }
    private void OnDisable()
    {
        //mainMenuInputs.MainMenuKeyboard.EnemyClick.Disable();
        //input.Disable();
        gameInputs.GameMovement.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        //   Player.GetComponent<Rigidbody>().velocity
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       // Pointer.transform.position = Vector3.Normalize(Player.GetComponent<Rigidbody>().velocity)*2;
        transform.rotation =  Quaternion.Euler(new Vector3(desiredRotationX , 0, desiredRotationZ ));
       
    }
    
    

    private void RotateUP(InputAction.CallbackContext context)
    {
      
        if (context.started)
        {
            if (CorHorizontalReverse != null) StopCoroutine(CorHorizontalReverse);
            corUp = StartCoroutine(ChangeRotationHorizontal());

        }
        else if(context.canceled)
        {
            if (CorHorizontalReverse != null) StopCoroutine(CorHorizontalReverse);
            if (corUp != null)  StopCoroutine(corUp);
            CorHorizontalReverse = StartCoroutine(ReverseHorizontalRotation());

        }
       



    }
    private void RotateDown(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            if (CorHorizontalReverse != null) StopCoroutine(CorHorizontalReverse);
            //if (corUpReverse != null) StopCoroutine(corUpReverse);
            corDown = StartCoroutine(ChangeRotationHorizontal(true));

        }
        else if (context.canceled)

        {
            if (CorHorizontalReverse != null) StopCoroutine(CorHorizontalReverse);
            if (corDown != null) StopCoroutine(corDown);
            CorHorizontalReverse = StartCoroutine(ReverseHorizontalRotation());

        }

    }
    private void RotateLeft(InputAction.CallbackContext context)
    {
        if(context.started)
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
    private void RotateRight(InputAction.CallbackContext context)
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
           
            while (desiredRotationX >=-MaxRotation)
            {
                desiredRotationX -= rotationPower;

                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;

        }
        while (desiredRotationX<= MaxRotation) 
        {
            desiredRotationX += rotationPower;

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

                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;


        }
        else if (desiredRotationX<0) 
        {
            while (desiredRotationX <= 0)
            {
                desiredRotationX += rotationPower;

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

                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;

        }
        while (desiredRotationZ <= MaxRotation)
        {
            desiredRotationZ += rotationPower;

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

                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;


        }
        else if (desiredRotationZ < 0)
        {
            while (desiredRotationZ <= 0)
            {
                desiredRotationZ += rotationPower;

                yield return new WaitForSeconds(rotationSpeed);
            }
            yield break;

        }



    }
}
