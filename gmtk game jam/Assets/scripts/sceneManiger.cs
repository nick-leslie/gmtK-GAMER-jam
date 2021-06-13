using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManiger : MonoBehaviour
{
    //private audioManiger aManiger;
    // Start is called before the first frame update
    void Start()
    {
        //aManiger = GameObject.FindGameObjectWithTag("audioManiger").GetComponent<audioManiger>();
        Application.targetFrameRate = 100;
    }
    //this starts the game by going to scene 1
    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    //this gose back to main menue by going to scene 0
    public void GoBackTOMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
    //this sets the new scene to be the active sce
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //gose to the win screen by loading scene 2
    public void YouWin()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    //alows for the the level to restetart by reloading the level
    public void ReloadLvl()
    {
        //MainCammra.GetComponent<>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
