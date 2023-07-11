using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoGraphy : MonoBehaviour
{
    public float Pitch { get; private set; }
    public float Yaw { get;private set;}

    public float mouseSensitivity = 5;
    public float cameraRotatingSpeed = 80;

    public float cameraYspeed = 5;

    private Transform target;
    private Transform _camera;
    [SerializeField] private AnimationCurve armLengthCurve;
    // Start is called before the first frame update
    private void Awake()
    {
        _camera = transform.GetChild(0);
    }
    void Start()
    {
        Pitch = 20;
        Yaw = 0;
    }

    public void InitCamera(Transform target)
    {
        this.target = target;
        transform.position = target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRotation();
        UpdatePosition();
        UpdateArmLength();
    }

    private void UpdateRotation()
    {
        Yaw += Input.GetAxis("Mouse X")*mouseSensitivity;
        Yaw += Input.GetAxis("Camera Rate X") * cameraRotatingSpeed * Time.deltaTime;
        //Pitch += Input.GetAxis("Mouse Y") * mouseSensitivity*0.1f;
        //Pitch += Input.GetAxis("Camera Rate Y") * cameraRotatingSpeed * Time.deltaTime;
        //Pitch=Mathf.Clamp(Pitch, -70, 90);

        transform.rotation=Quaternion.Euler(Pitch,Yaw,0);
    }


    private void UpdatePosition()
    {
        Vector3 position = target.position;
        float newY = Mathf.Lerp(transform.position.y, position.y, Time.deltaTime * cameraYspeed);
        transform.position = new Vector3(position.x, newY, position.z);
    } 
    private void UpdateArmLength()
    {
        _camera.localPosition = new Vector3(0, 0, armLengthCurve.Evaluate(Pitch) * -1);
    }
}
