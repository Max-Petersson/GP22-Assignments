using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
