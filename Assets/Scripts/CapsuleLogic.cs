using System.Collections;
using UnityEngine;

public class CapsuleLogic : MonoBehaviour
{
    private Renderer capsuleRenderer;
    private ComboManager comboManager;
    public Material[] goodMaterials;
    public Material[] badMaterials;

    public Light glowLight;

    public bool isEnemy;

    private bool isUp = false;

    void Start()
    {
        capsuleRenderer = GetComponent<Renderer>();

        comboManager = FindFirstObjectByType<ComboManager>();

        // start random loop
        StartCoroutine(MoleLoop());
    }

    IEnumerator MoleLoop()
    {
        while (true)
        {
            // random delay before appearing
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            RandomizeType();

            // SPAWN (go up)
            yield return StartCoroutine(Spawn());

            isUp = true;

            // stay visible
            yield return new WaitForSeconds(1f);

            // DESPAWN (go down)
            yield return StartCoroutine(Despawn());

            isUp = false;
        }
    }

    void RandomizeType()
    {
        isEnemy = Random.value > 0.5f;

        if (isEnemy)
        {
            int randomIndex = Random.Range(0, badMaterials.Length);

            capsuleRenderer.material = badMaterials[randomIndex];

            glowLight.color = Color.red;
        }
        else
        {
            int randomIndex = Random.Range(0, goodMaterials.Length);

            capsuleRenderer.material = goodMaterials[randomIndex];

            glowLight.color = Color.green;
        }
    }

    void OnMouseDown()
    {
        if (!isUp) return;

        // red enemy - good
        if (isEnemy)
        {
            if (comboManager != null)
            {
                comboManager.RegisterHit();
            }

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(1);
            }
        }
        // green character - bad
        else
        {
            if (comboManager != null)
            {
                comboManager.RegisterMiss();
            }

            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(-1);
            }
        }

        StopAllCoroutines();

        StartCoroutine(HitMole());
    }

    IEnumerator HitMole()
    {
        yield return StartCoroutine(Despawn());

        isUp = false;

        StartCoroutine(MoleLoop());
    }

    IEnumerator Despawn()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.05f);

            transform.Translate(new Vector3(0, -0.2f, 0));
        }
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.05f);

            transform.Translate(new Vector3(0, 0.2f, 0));
        }
    }
}