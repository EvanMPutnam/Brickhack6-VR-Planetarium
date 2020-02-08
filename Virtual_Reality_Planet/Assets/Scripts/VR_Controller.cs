using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Controller : MonoBehaviour
{

    //Public object that scales/moves to control star location.
    public GameObject particleContainer;
    public GameObject floor;

    //Private transform (Assigned once for performance)
    private Transform particleContainerTransform;

    private const float ROTATION_SPEED = 0.5f;
    private const float VR_CONTROLLER_THRESHOLD = 0.5f;


    private float timer = 0;
    private bool timer_down = false;
    private bool active = true;


    // Start is called before the first frame update
    void Start()
    {
        particleContainerTransform = particleContainer.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation of starfield.
        Vector2 vec = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        //Rotate around the y axis
        if(vec.y > VR_CONTROLLER_THRESHOLD)
        {
           particleContainerTransform.Rotate(ROTATION_SPEED, 0, 0, Space.Self);
        }
        else if(vec.y < -VR_CONTROLLER_THRESHOLD)
        {
            particleContainerTransform.Rotate(-ROTATION_SPEED, 0, 0, Space.Self);   
        }

        //Rotate around the x axis.
        if(vec.x > VR_CONTROLLER_THRESHOLD)
        {
            particleContainerTransform.Rotate(0, ROTATION_SPEED, 0, Space.Self);
        }
        else if(vec.x < -VR_CONTROLLER_THRESHOLD)
        {
            particleContainerTransform.Rotate(0,  -ROTATION_SPEED, 0, Space.Self);
        }

        if(timer_down == true){
            timer += 1;
        }

        if(timer == 1000){
            timer_down = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)){
            timer_down = true;
            floor.SetActive(!active);
            active = !active;
        }


    }
}
