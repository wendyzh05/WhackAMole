using System.Collections;
using UnityEngine;

public class CapsuleLogic : MonoBehaviour
{

    private Renderer capsuleRenderer;
    private ComboManager comboManager;

    void Start()
    {
        capsuleRenderer = GetComponent<Renderer>();
        StartCoroutine(Spawn());
        comboManager = FindFirstObjectByType<ComboManager>();
    }

    void OnMouseDown()
    {
        //interacts w combo
        if (comboManager != null)
        {
            comboManager.RegisterHit();
        }

        StartCoroutine(Despawn());
    }

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
