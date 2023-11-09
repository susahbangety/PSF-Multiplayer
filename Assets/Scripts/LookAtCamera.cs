using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookAtCamera : MonoBehaviour
{
    private GameObject _camera;

    private void Awake()
    {
        _camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3(_camera.transform.position.x, transform.position.y, _camera.transform.position.z);
        transform.LookAt(targetPostition);
    }
}
