using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;



public class BreakSwitcher : MonoBehaviour
{
    Random rnd = new Random();
    public static int[] SceneIndex = { -1, -1, -1, -1, -1 };
    IEnumerator Rest()
     {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(SceneIndex[i]);
        }
         yield return new WaitForSeconds(10f); // wait 10f-second break until next round
         //StartCoroutine(Gun.coroutine);
         if (SceneIndex[4] == -1)
         {
             int k;
             while (true)
             {
                 k = rnd.Next(0, 5);
                 bool match = false;

                 for (int i = 0; i < 5; i++)
                 {
                     if (k == SceneIndex[i])
                     {
                         match = true;
                     }
                 }

                 if (match == false)
                 {
                     break;
                 }

             }
             for (int i = 0; i < 5; i++)
             {
                 if (SceneIndex[i] == -1)
                 {
                     SceneIndex[i] = k;
                     break;
                 }
             }

             SceneManager.LoadScene(k);
         }
         else
         {
             SceneManager.LoadScene(7);
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
