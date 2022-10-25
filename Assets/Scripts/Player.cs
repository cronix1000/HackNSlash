using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;

    float angle;
    float smoothMoveVelocity;
    float smoothInputMagnitude;
    Vector3 veclocity;

    Rigidbody rigidbody;
    bool disabled;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //set Input dir
        Vector3 inputDir = Vector3.zero;
        
        //Take player keyboard inpuit
        inputDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        //convert input to magnitude
        float inputMagnitude = inputDir.magnitude;

        //smooth the magnaitude for smoother movement
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);


        float inputAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, inputAngle, Time.deltaTime * turnSpeed * inputMagnitude);

        veclocity = transform.forward * speed * smoothInputMagnitude;

        Debug.DrawRay(transform.position, inputDir, Color.green);
    }
    private void FixedUpdate()
    {
        rigidbody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rigidbody.MovePosition(rigidbody.position + veclocity * Time.deltaTime);
    }
}
