using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float delay;

    private void Start()
    {
        // destroy an object after set time
        Destroy(gameObject, delay);

    }






}
