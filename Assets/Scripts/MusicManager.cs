using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Level Music")]
    public AudioClip level1Music;
    public AudioClip level2Music;
    public AudioClip level3Music;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += PlayMusicForScene;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= PlayMusicForScene;
    }

    void PlayMusicForScene(Scene scene, LoadSceneMode mode)
    {
        AudioClip newClip = null;

        if (scene.name == "Level1")
            newClip = level1Music;
        else if (scene.name == "Level2")
            newClip = level2Music;
        else if (scene.name == "Level3")
            newClip = level3Music;

        if (newClip != null && audioSource.clip != newClip)
        {
            audioSource.clip = newClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
