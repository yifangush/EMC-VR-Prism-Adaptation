using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakSwitcher : MonoBehaviour
{
    IEnumerator Rest()
    {
        yield return new WaitForSeconds(10f); // wait 10f-second break until next round
        StartCoroutine(Gun.coroutine);
        if (Gun.round <= 4)
        {
            SceneManager.LoadScene(Gun.round + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Rest());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
