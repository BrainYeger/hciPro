using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animation anim;
    private Vector3 tempLocation;
    public float Sensitivity;
    public float StayTime;
    private int Counts;
    private int count=0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        tempLocation = transform.localPosition;
        Counts = Mathf.RoundToInt(StayTime / Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if ((tempLocation - transform.localPosition).magnitude > Sensitivity)
        {
            anim.Play("Walk");
            tempLocation = transform.localPosition;
            count = 0;
        }
        else count++;
        if (count > Counts)
        {
            count = 0;
            anim.Play("Idle");
        }
    }
}
