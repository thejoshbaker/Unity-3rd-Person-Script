using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region README
/*
 * READ THIS
 *
 * Attatch this script to the camera your using
 * 
*/
#endregion

public class Camera3P : MonoBehaviour
{
    [Header("Settings")]

    public  bool    MouseLock   = true;
    public  float   RotateSpeed = 5;
    private Vector3 Offset; 

    [Header("Requirements")]

    public GameObject Player;
    public GameObject Aim;

    void Awake()
    {
        Offset = Player.transform.position - transform.position;
    }
    void LateUpdate()
    {
        // LOOK //

        float hori = Input.GetAxis("Mouse X") * RotateSpeed;
        Player.transform.Rotate(0, hori, 0);

        float newwAngle    = Player.transform.eulerAngles.y;
        Quaternion Rotat   = Quaternion.Euler(0, newwAngle, 0);
        transform.position = Player.transform.position - (Rotat * Offset);

        transform.LookAt(Aim.transform);

        // LOCK //
        if (MouseLock == true) 
        { 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible   = false;
        }
        else 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible   = true;
        }
    }
}

