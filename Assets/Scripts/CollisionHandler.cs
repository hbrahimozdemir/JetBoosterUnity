using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
     void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is Launch Pad");
                break;
            case "Finish":
               StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("This is Fuel");
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        //todo add SFX upon success
        //todo add particle FX
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",levelLoadDelay);
    }
    void StartCrashSequence()
    {
        //todo add SFX upon Crash
        //todo add particle FX
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",levelLoadDelay);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // this is get the level index
        SceneManager.LoadScene(currentSceneIndex); // or can SceneManager.LoadScene(0); can use index or name 
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // this is get the level index
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
