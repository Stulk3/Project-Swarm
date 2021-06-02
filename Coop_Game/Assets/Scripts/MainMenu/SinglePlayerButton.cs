using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class SinglePlayerButton : MonoBehaviour
{
    public void Play ()
    {
        SceneManager.LoadScene("SinglePlayerTest");
    }
}
