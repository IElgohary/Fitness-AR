using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {
    public GameObject canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void start() {
        SceneManager.LoadScene("SampleScene");
    }

    public void howTo()
    {
        canvas.SetActive(true);
    }

    public void back() {
        canvas.SetActive(false);
    }

    public void quit(){
        Application.Quit();
    }
}
