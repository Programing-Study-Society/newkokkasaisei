using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Camera cam;
    private Vector3 startPos;
    private Vector3 startAngle;
    // Start is called before the first frame update
    void Start()
    {
        cam = cam.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null)
        {
            return;
        }
        
        if (Input.GetMouseButton(0))
        {
            float moveX = Input.GetAxis("Mouse X") * globalValue.sensitiveMove;
            float moveY = Input.GetAxis("Mouse Y") * globalValue.sensitiveMove;
            cam.transform.localPosition -= new Vector3(moveX, moveY, 0.0f);
        }
        else if (Input.GetMouseButton(1))
        {
            float moveX = Input.GetAxis("Mouse X") * globalValue.sensitiveMove;
            float moveY = Input.GetAxis("Mouse Y") * globalValue.sensitiveMove;
            cam.transform.eulerAngles -= new Vector3(moveY,moveX, 0.0f);
        }
        
        float moveZ = Input.GetAxis("Mouse ScrollWheel") * globalValue.sensitiveZoom;
        cam.transform.position += cam.transform.forward * moveZ;
    }
}
