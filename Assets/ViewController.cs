using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 1.0f;
    public float zoomSpeed = 1.0f;
    public float minZoomDistance = 1.0f;
    public float maxZoomDistance = 20.0f;

    private float distance;
    private Vector2 lastSingleTouchPosition;
    private Vector2 touch1PrevPos, touch2PrevPos;
    private Vector3 offset;

    void Start()
    {
        offset = target.position - transform.position;
        distance = offset.magnitude;
    }

    void Update()
    {
        //phone
        if (Input.touchCount == 1)
        {
            Touch singleTouch = Input.GetTouch(0);

            if (singleTouch.phase == TouchPhase.Moved)
            {
                float rotationAroundYAxis = -singleTouch.deltaPosition.x * rotationSpeed;
                float rotationAroundXAxis = singleTouch.deltaPosition.y * rotationSpeed;
                // if (rotationAroundXAxis > rotationAroundYAxis) {
                //     rotationAroundYAxis = 0;
                // } else {
                //     rotationAroundXAxis = 0;
                // }
                transform.Rotate(new Vector3(0, rotationAroundYAxis, 0));
            }

            lastSingleTouchPosition = singleTouch.position;
        }
        else if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                touch1PrevPos = touch1.position - touch1.deltaPosition;
                touch2PrevPos = touch2.position - touch2.deltaPosition;

                float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
                float touchDeltaMag = (touch1.position - touch2.position).magnitude;

                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                distance += deltaMagnitudeDiff * zoomSpeed * Time.deltaTime;
                distance = Mathf.Clamp(distance, minZoomDistance, maxZoomDistance);

                transform.position = target.position + (-transform.forward * distance);
            }
        }





        //pc
        // Left Mouse Button for rotation
        // if (Input.GetMouseButton(0))
        // {
        //     float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        //     float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;
        //     //transform.RotateAround(target.position, Vector3.up, horizontal);
        //     //transform.RotateAround(target.position, transform.right, -vertical);
        //     // if (vertical > horizontal) {
        //     //     horizontal = 0;
        //     // } else {
        //     //     vertical = 0;
        //     // }
        //     transform.Rotate(new Vector3(0, horizontal, 0));
        // }

        // Mouse ScrollWheel for zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minZoomDistance, maxZoomDistance);  // Limit Zoom

        transform.position = target.position - (transform.rotation * Vector3.forward * distance);
    }
}
