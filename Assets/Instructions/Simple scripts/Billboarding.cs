using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    Vector3 cameraDir;

    void Update()
    {
        cameraDir = Camera.main.transform.forward;
        transform.rotation = Quaternion.LookRotation(cameraDir);
        
    }
}
