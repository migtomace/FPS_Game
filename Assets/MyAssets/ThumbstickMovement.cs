using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ThumbstickMovement : MonoBehaviour
{

    public XRNode inputSource;
    public float speed = 1.0f;
    private Vector2 inputAxis;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);
        direction = transform.TransformDirection(direction);
        characterController.Move(direction * speed * Time.deltaTime);
    }
}