using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float slowTime = 10f;

    public void GameOver()
    {
        StartCoroutine(Restart());
    }


    IEnumerator Restart()
    {

        Time.timeScale = 1/slowTime;
        Time.fixedDeltaTime =Time.fixedDeltaTime / slowTime;

        yield return new WaitForSeconds(1f / slowTime);

        Time.timeScale = 1f;
        Time.fixedDeltaTime =Time.fixedDeltaTime * slowTime;

        SceneManager.LoadScene(0);
    }

}
