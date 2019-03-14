using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{public Transform Object;
    Vector3 position;

    internal Vector3 ScreenToWorldPoint(Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Object.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = Object.position;
        position.z = -10f;
        position.x = -6f;
        transform.position = Vector3.Lerp(transform.position, position, 1f * Time.deltaTime);
    }
}
