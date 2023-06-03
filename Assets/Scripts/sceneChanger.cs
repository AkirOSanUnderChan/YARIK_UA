using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSceneToMainWorld()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadingScreenOn()
    {
        canvas.SetActive(true);
    }
}
