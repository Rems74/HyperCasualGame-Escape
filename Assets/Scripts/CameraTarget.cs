using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    [SerializeField] Vector3 offset;
    [SerializeField] Transform target;

    Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 pos = new Vector3(0, 0, target.position.z);
        //nouvelle position
        Vector3 newPos = offset + pos;
        transform.position = newPos;

        //oriente la vision de la camera
        transform.LookAt(target);
    }
}
