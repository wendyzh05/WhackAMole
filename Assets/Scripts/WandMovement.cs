using UnityEngine;

public class WandMovement : MonoBehaviour
{

    public float speed = 10f;

    public Transform Board;

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.transform.position.y;

        Vector3 targetedPoint = Camera.main.ScreenToWorldPoint(mousePos);

        if (Board != null)
        {
            // Point the object's forward axis (blue arrow) toward the target's position
            transform.LookAt(Board.position);
        }

        if (mousePos.y < 200 & mousePos.y > 140)
        {
            targetedPoint.y = transform.position.y;
            transform.position = targetedPoint;
        }
        else
        {
            targetedPoint.y = transform.position.y;
            transform.position = targetedPoint;
        }

        Debug.Log(mousePos);

    }
    
    /*
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
