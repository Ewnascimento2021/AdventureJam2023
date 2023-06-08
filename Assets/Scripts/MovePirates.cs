using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePirates : MonoBehaviour
{
    [SerializeField]
    private float speedNavio;

    private float rotation;
    private float rotationZ;
    private bool invertX;
    private bool invertZ;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (invertX == false)
        {
            rotation += speedNavio * Time.deltaTime;
            transform.eulerAngles = new Vector3(rotation, 70, 0);
            if (rotation >= 1f)
            {
                invertX = true;
            }
        }
        else if (invertX == true) 
        {
            rotation += speedNavio * Time.deltaTime * -1;
            transform.eulerAngles = new Vector3(rotation, 70, 0);
            if (rotation <= -1f)
            {
                invertX = false;
            }
        }

        if (invertZ == false)
        {
            rotationZ += speedNavio * Time.deltaTime;
            transform.eulerAngles = new Vector3(rotation, 70, rotationZ);
            if (rotation >= 1f)
            {
                invertZ = true;
            }
        }
        else if (invertZ == true)
        {
            rotationZ += speedNavio * Time.deltaTime * -1;
            transform.eulerAngles = new Vector3(rotation, 70, rotationZ);
            if (rotation <= -1f)
            {
                invertZ = false;
            }
        }
    }
}
