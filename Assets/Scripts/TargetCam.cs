using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float offSet;

    private void Start()
    {

    }
    void Update()
    {
        transform.position = new Vector3(0, target.position.y, target.position.z + offSet);
    }
}
