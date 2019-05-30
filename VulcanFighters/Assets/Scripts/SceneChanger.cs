using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void StartDemo()
	{
		SceneManager.LoadScene("Demo");
	}
	public void Close()
	{
		Application.Quit();
	}
	public void HowTo()
	{
		SceneManager.LoadScene("HowTo");
	}
	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
