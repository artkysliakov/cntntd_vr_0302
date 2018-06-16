using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadScene : MonoBehaviour {

    public void ReloadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
