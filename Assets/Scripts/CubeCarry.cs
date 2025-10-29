using UnityEngine;

public class CubeCarry : MonoBehaviour
{
    public Transform carryPoint; // assigned in Inspector
    public float pickupRange = 2f;

    private Rigidbody carriedCube;

    void Update()
{
    if (carriedCube != null)
    {
        // Move cube to a point in front of the camera
        carriedCube.position = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
        
        // Optional: make cube face the same way as the camera
        carriedCube.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }

    // Pickup / Drop logic
    if (Input.GetKeyDown(KeyCode.E))
    {
        if (carriedCube == null)
            TryPickup();
        else
            DropCube();
    }
}


    void TryPickup()
    {
        // Ray from camera (so it matches your view)
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    carriedCube = rb;
                    carriedCube.isKinematic = true; // disable physics while holding
                }
            }
        }
    }

    void DropCube()
    {
        carriedCube.isKinematic = false;
        carriedCube = null;
    }
}
