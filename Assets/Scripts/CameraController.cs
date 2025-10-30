using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition;
    public float sensitivityX = 100f;
    public float sensitivityY = 100f;
    public Transform orientation;

    private float xRotation;
    private float yRotation;

    private PlayerControls controls;
    private Vector2 lookInput;

    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        controls.Player.Look.Enable();
    }

    void OnDisable()
    {
        controls.Player.Look.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        transform.position = cameraPosition.position;

        // Get mouse input from new Input System
        lookInput = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = lookInput.x * Time.deltaTime * sensitivityX;
        float mouseY = lookInput.y * Time.deltaTime * sensitivityY;

        yRotation += mouseX;
        xRotation -= mouseY; // invert Y so it's natural

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
