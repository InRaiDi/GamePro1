using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScene : MonoBehaviour
{
    [SerializeField]

    private float t;



    private IEnumerator Start()
    {

        yield return new WaitForSeconds(t);

        SceneManager.LoadScene("Menu");

    }
}
