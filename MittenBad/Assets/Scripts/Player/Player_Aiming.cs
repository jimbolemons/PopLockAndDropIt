using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Aiming : MonoBehaviour
{
    // Attack start transform
    [SerializeField]
    private Transform aiming;

    // Axe GameObject
    public GameObject racket;

    // Origin of rotation for axe attack
    public GameObject origin;

    private void Awake() // Locate transform on instantiation
    {
        aiming = transform.Find("Racket_Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse location
        Vector3 mousePosition = GetWorldPosition();
        // Calculate aiming direction
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        // Calculate angle difference between start and aimDirection
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        // Set eulerAngles of the Attack Start Transform
        aiming.eulerAngles = new Vector3(0, 0, angle);
        // Rotate origin of attack using the calculated angle difference 
        origin.transform.Rotate(transform.forward * angle * Time.deltaTime);

    }

    public static Vector3 GetWorldPosition() // Mouse Vector3 Location
    {
        Vector3 location = GetWorldPositionForZ(Input.mousePosition, Camera.main);
        location.z = 0f;
        return location;
    }

    public static Vector3 GetWorldPositionForZ(Vector3 screenPosition, Camera worldCamera) // Assist GetWorldPosition to generate Mouse Vector3 Location
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
