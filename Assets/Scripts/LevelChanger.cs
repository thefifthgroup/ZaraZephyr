using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public AudioSource playSound;
    public Animator startButton;
    public Animator fadeOut;
    private int levelToLoad;
    private int currentScene;

    // Update is called once per frame
    void Update()
    {   
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 0)
        {
            OnStartScreenGetInput();
        }
    }
    
    private void OnStartScreenGetInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FadeToLevelFromStart(1);
        }
    }
    public void FadeToLevelFromStart (int levelIndex)
    {
        playSound.Play();
        levelToLoad = levelIndex;
        fadeOut.SetTrigger("FadeOut");
        startButton.SetTrigger("Selected");
    } 
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        fadeOut.SetTrigger("FadeOut");
    } 

    // This funciton is set as an animation event
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

