using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamerapoint : MonoBehaviour
{

    public GameObject ball;
    private Rigidbody ballRB;
    // Start is called before the first frame update
    void Start()
    {
        ballRB = ball.GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DesiredRotation = ballRB.velocity.normalized;
       // transform.rotation = Quaternion.LookRotation(DesiredRotation, new Vector3(0, 0, 1));
    }
}
