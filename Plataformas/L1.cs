using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1 : MonoBehaviour
{
    void Awake()
    {
        var t = - (5 * Camera.main.aspect);
        transform.position = new Vector3(t, transform.position.y);
    }
}
