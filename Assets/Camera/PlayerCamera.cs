using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private Transform target;
    public float offSetY;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        var targetPosi = new Vector3(target.position.x, target.position.y + offSetY, transform.position.z);
        transform.position = targetPosi;
    }
}
