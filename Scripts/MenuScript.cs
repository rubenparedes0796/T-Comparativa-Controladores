using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void PlayGame(int escena1)
    {
        SceneManager.LoadScene(escena1);
    }


    public void Quit()
    {
        Application.Quit();
        //Debug.Log("Quit");
    }


}
