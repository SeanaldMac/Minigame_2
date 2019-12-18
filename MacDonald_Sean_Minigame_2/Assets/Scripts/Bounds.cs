using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{


    // destroys objcts that collide with bounds (save memory space)
    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);


    }
}
