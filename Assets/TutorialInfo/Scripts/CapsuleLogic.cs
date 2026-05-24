using System.Collections;
using UnityEngine;

public class CapsuleLogic : MonoBehaviour
{

    private Renderer capsuleRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        capsuleRenderer = GetComponent<Renderer>();
        StartCoroutine(Spawn());
    }

    void OnMouseDown() {
        StartCoroutine(Despawn());
    }

    // Instead of immediately moving the Z to its desired place, this function does it incrementally, making it look "smoother"
    // Runtime: a second
    IEnumerator Despawn()
    {;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f); // waits for a tenth of a second
            transform.Translate(new Vector3(0, -0.2f, 0));
        }
        yield return new WaitForSeconds(2);
        StartCoroutine(Spawn());
    }

    // Same as Despawn but in reverse 
    IEnumerator Spawn()
    {;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.1f); // waits for a tenth of a second
            transform.Translate(new Vector3(0, 0.2f, 0));
        }
    }
}
