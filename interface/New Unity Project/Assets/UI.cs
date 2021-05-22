using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitMenu()
    {
        Application.Quit();
    }
}
