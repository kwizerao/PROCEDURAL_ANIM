using UnityEngine;
using UnityEngine.UIElements;


public class ProceduralMovement : MonoBehaviour
{

    public float rotationSpeed = 5.0f;
   
    public Transform leftLeg;
    public Transform rightLeg;
    public Transform leftHand;
    public Transform rightHand;
    public Transform spline;
    public Transform head;


    public float speed = 1.0f;
    public float rotationAngle = 30.0f;
    public float rotationAngleSpline = 15.0f;
    public float rotationAngleHands = 20f;
    public float offSet = 17f;
    public float offSetLeg = 0f;
    public float offSpline = 0f;
    public float handSpeed = 10f;

    public float handRotationAngle = 30.0f;

    public float movementSpeed = 20;

    float waveOffset = 0f;
    float waveOffsetSpline = 0f;
    float waveOffsetHands = 0f;

    public float dodgeAngle = 45;
    public float cooldownTime = 1.0f;

    public float legRotationAngle = 15.0f;

    public float runningTime = 0.0f;
    bool contact = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("obstacle"))
        {
            contact = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            contact = false; 
        }
    }

    private float walkCycle = 0f;
    private float stepHeight = 0.2f;
    private float timeChange = 0.0f;
    private float stepCycle = 0.5f;


    void Update()
    {


        transform.position += (-transform.right * movementSpeed * Time.deltaTime);

        if (contact)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(transform.localRotation.x, transform.localRotation.y + dodgeAngle, transform.localRotation.z), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(transform.localRotation.x, -90, transform.localRotation.z), Time.deltaTime * rotationSpeed);
        }








        waveOffset = Mathf.Sin(Time.time * speed) * rotationAngle;
        waveOffsetSpline = Mathf.Sin(Time.time * speed) * rotationAngleSpline;



        timeChange += Time.deltaTime;

        walkCycle = Mathf.Repeat(timeChange / stepCycle, 1f);
        //  turnCycle = Mathf.Repeat(timeSinceStep, 10f);

        float leftLegHeight = Mathf.Sin(walkCycle * Mathf.PI * 2) * stepHeight;
        float rightLegHeight = Mathf.Sin((walkCycle + 0.5f) * Mathf.PI * 2) * stepHeight;

        leftLeg.localPosition = new Vector3(leftLeg.localPosition.x, leftLegHeight, 0);
        rightLeg.localPosition = new Vector3(rightLeg.localPosition.x, rightLegHeight, 0);




        // waveOffsetHands = Mathf.Sin(Time.time * speed) * rotationAngleHands;

        //leftLeg.localRotation = Quaternion.Euler(waveOffset  + offSetLeg, leftLeg.localRotation.y, leftLeg.localRotation.z);
        //rightLeg.localRotation = Quaternion.Euler(-waveOffset + offSetLeg, rightLeg.localRotation.y, leftLeg.localRotation.z);

        //float legWaveOffset = Mathf.PingPong(Time.time * speed * 2, legRotationAngle * 2) - legRotationAngle;

        //leftLeg.localRotation = Quaternion.Euler(legWaveOffset + offSetLeg, 0, 0);
        //rightLeg.localRotation = Quaternion.Euler(-legWaveOffset + offSetLeg, 0, 0);



        //leftLeg.rotation = Quaternion.Euler(waveOffset + offSetLeg, 0, 0);
        //rightLeg.rotation = Quaternion.Euler(-waveOffset + offSetLeg, 0, 0);


        //leftLeg.localRotation = Quaternion.Euler(waveOffset + offSetLeg, 0, 0);
        //rightLeg.localRotation = Quaternion.Euler(-waveOffset + offSetLeg, 0, 0);


        //leftHand.rotation = Quaternion.Euler(0, 0, waveOffset);
        //rightHand.rotation = Quaternion.Euler(0, 0, -waveOffset);

        spline.localRotation = Quaternion.Euler(waveOffsetSpline + offSpline, 0, 0);


        float handWaveOffset = Mathf.PingPong(Time.time * handSpeed, handRotationAngle * 2) - handRotationAngle;
        leftHand.localRotation = Quaternion.Euler(0, 0, handWaveOffset);
        rightHand.localRotation = Quaternion.Euler(0, 0,  handWaveOffset);

        //leftHand.rotation = Quaternion.Euler(waveOffsetHands + offSet, leftHand.rotation.y, leftHand.rotation.z);
        //rightHand.rotation = Quaternion.Euler( -waveOffsetHands + offSet, rightHand.rotation.y, rightHand.rotation.z);

        head.localRotation = Quaternion.Euler(head.localRotation.x, head.localRotation.y, waveOffset * 0.5f);
    }
}

