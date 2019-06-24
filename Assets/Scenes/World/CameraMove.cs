using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    [SerializeField]private float distance;
    [SerializeField]private float maxD;
    [SerializeField]private float minD;
    
    [SerializeField]private float speedX;
    [SerializeField]private float speedY;

    [SerializeField]private float MinY;
    [SerializeField]private float MaxY;
    [SerializeField] private float ZoomSpeed;

    private float x = 0;
    private float y = 0;
    
    private Vector2 lastPosition1 = new Vector2(0,0);
    private Vector2 lastPosition2 = new Vector2(0,0);
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
        transform.position = target.position + new Vector3(0, offsetY, offsetZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                x += Input.GetAxis("Mouse X") * speedX * 0.02f;
                y -= Input.GetAxis("Mouse Y") * speedY * 0.02f;
            }
        }

        if (Input.touchCount > 1)
            if (Input.GetTouch(0).phase == TouchPhase.Moved ||
                Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                var temp1 = Input.GetTouch(0).position;
                var temp2 = Input.GetTouch(1).position;
                if (isEnlarge(lastPosition1, lastPosition2, temp1, temp2))
                {
                    if (distance > minD)
                        distance -= ZoomSpeed;
                }
                else {
                    if (distance < maxD)
                    distance += ZoomSpeed;
                }              
                lastPosition1 = temp1;
                lastPosition2 = temp2;
            }
    }

    private void LateUpdate()
    {
        if (target)
        {
            if (y < -360) y += 360;
            if (y > 360) y -= 360;
            y = Mathf.Clamp(y, MinY, MaxY);
            
            Quaternion rotation = Quaternion.Euler(y,x,0);
            Vector3 position = target.position + rotation * new Vector3(0, 0, -distance);
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    bool isEnlarge(Vector2 lp1, Vector2 lp2, Vector2 p1, Vector2 p2)
    {
        float l1 = (lp1.x - lp2.x) * (lp1.x - lp2.x) + (lp1.y - lp2.y) * (lp1.y - lp2.y);
        float l2 = (p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y);

        if (l1 < l2)
            return true;
        else return false;
    }

}
