using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region README

/* READ THIS
 * 
 * Attatch this script to the charcter you want to move
 * 
*/

#endregion

public class Movement3P : MonoBehaviour
{
    [Header("Settings")]
    public bool  CanMove    = true;
    public float Speed      = 2;
    public float RunSpeed   = 10;
    public float JumpHeight = 5f;

    private bool Grounded = false;

    [Header("Keys")]
    public KeyCode Forewards = KeyCode.W;
    public KeyCode Left      = KeyCode.A;
    public KeyCode Right     = KeyCode.D;
    public KeyCode Backwards = KeyCode.S;
    public KeyCode Run       = KeyCode.LeftShift;
    public KeyCode Jump      = KeyCode.Space;

    [Header("Requirments")]
    public Rigidbody  Rigidbody;

    void Start()
    {
        Rigidbody.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Grounded = true;  
    }
    void OnCollisionExit(Collision collision)
    {
        Grounded = false;    
    }
    void Update()
    {
        if (CanMove)
        {
            if (Input.GetKey(Forewards)) 
            {
                transform.position += transform.rotation * Vector3.forward * Speed * Time.deltaTime;
                if (Input.GetKey(Run)) 
                {
                    transform.position += transform.rotation * Vector3.forward * RunSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(Left)) 
            {
                transform.position += transform.rotation * Vector3.left * Speed * Time.deltaTime;
                if (Input.GetKey(Run))
                {
                    transform.position += transform.rotation * Vector3.left * RunSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(Right))
            {
                transform.position += transform.rotation * Vector3.right * Speed * Time.deltaTime;
                if (Input.GetKey(Run))
                {
                    transform.position += transform.rotation * Vector3.right * RunSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(Backwards))
            {
                transform.position += transform.rotation * Vector3.back * Speed * Time.deltaTime;
                if (Input.GetKey(Run))
                {
                    transform.position += transform.rotation * Vector3.back * RunSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKeyDown(Jump)) 
            { 
                if (Grounded == true) 
                {
                    Rigidbody.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
                }
            }
        }
    }
}

