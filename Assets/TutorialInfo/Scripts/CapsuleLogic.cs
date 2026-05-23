using System.Collections;
using UnityEngine;

public class CapsuleLogic : MonoBehaviour
{

    private Renderer capsuleRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        capsuleRenderer = GetComponent<Renderer>();
    }
    
    // if clicked by the mouse, change thecolor of the capsule to red, wait a second, and then decrease it's Z value by whatever necessary to no longer be seenonthe board

    void OnMouseDown() {
        Debug.Log("Object Clicked");
        capsuleRenderer.material.color = new Color(0.5f, 1f, 5f);
        StartCoroutine(WaitAndPrint());
        
        //for (int i = 0; i < 5; i++)
        //{
        //transform.Translate(new Vector3(0, -40f, 0) * Time.deltaTime);
        //}
        
    }

    IEnumerator WaitAndPrint()
    {;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f);
            transform.Translate(new Vector3(0, -40f, 0) * Time.deltaTime);
        }
    }
}
