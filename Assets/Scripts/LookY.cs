using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script should be attached to the camera!
public class LookY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!Cursor.visible) {
            //get input
            float mouseY = Input.GetAxis("Mouse Y");

            transform.localEulerAngles = new Vector3(
                //grab updated x y and z angles and save over old angles
                transform.localEulerAngles.x - mouseY,
                transform.localEulerAngles.y,
                transform.localEulerAngles.z
            );
        }
        


    }
}
