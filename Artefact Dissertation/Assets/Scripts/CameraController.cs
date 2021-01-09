﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed;
    public float panBorderThickness;
    public Vector2 panLimit;
    public float scrollSpeed;
    public float minY;
    public float maxY;
   







    void Update()
    {
        Vector3 pos = transform.position;
        if(Input.GetKey("w")||Input.mousePosition.y>=Screen.height-panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <=  panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }


        float scroll=Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed *100f* Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z= Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);







        transform.position = pos;
    }
}
