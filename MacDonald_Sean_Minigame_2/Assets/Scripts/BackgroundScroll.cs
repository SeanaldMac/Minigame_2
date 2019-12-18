using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float startY, endY, speed;







    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= speed * Time.deltaTime; // y changes by units per second

        // loops background
        if(pos.y < endY)
            pos.y = startY;

        transform.position = pos;

    }
}
