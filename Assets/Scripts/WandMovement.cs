using UnityEngine;

public class WandMovement : MonoBehaviour
{
    public Transform Board;

    [Header("Loose Follow")]
    public float followSpeed = 6f;
    public Vector3 screenOffset = new Vector3(2f, 0f, 0f);

    [Header("Wand Flick")]
    public float flickAngle = 25f;
    public float flickSpeed = 15f;

    private float currentFlick = 0f;
    private float targetFlick = 0f;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.y;

        Vector3 targetPoint = Camera.main.ScreenToWorldPoint(mousePos);
        targetPoint.y = transform.position.y;

        Vector3 desiredPosition = targetPoint + screenOffset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime
        );

        if (Board != null)
        {
            transform.LookAt(Board.position);
        }

        currentFlick = Mathf.Lerp(
            currentFlick,
            targetFlick,
            flickSpeed * Time.deltaTime
        );

        transform.Rotate(Vector3.right, currentFlick);

        targetFlick = Mathf.Lerp(
            targetFlick,
            0f,
            flickSpeed * Time.deltaTime
        );

        if (Input.GetMouseButtonDown(0))
        {
            Flick();
        }
    }

    void Flick()
    {
        targetFlick = flickAngle;
    }
}


