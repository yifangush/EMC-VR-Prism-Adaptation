using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class SceneLoader : MonoBehaviour
{
    Random rnd = new Random();

    IEnumerator SwitchScene()
    {
            yield return new WaitForSeconds(3f);
            CollisionBullet.totalScore = 0;
            print("score min reached - loading next scene");
            print("score min reached - loading next scene");
            print("Leaving Scene " + SceneManager.GetActiveScene().buildIndex.ToString()); // outputs the scene number
            print("Entering Scene " + (SceneManager.GetActiveScene().buildIndex + 1).ToString()); // outputs next scene number
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // moves to the scene with the next index
    }
            // Start is called before the first frame update
    
            
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed - loading next scene");
            print("Leaving Scene " + SceneManager.GetActiveScene().buildIndex.ToString()); // outputs the scene number
            print("Entering Scene 0"); // outputs next scene number
            SceneManager.LoadScene(6); // moves to the scene with the next index
        }

        /*if (false && CollisionBullet.totalScore >= 150) // remove 0 &&
        {
            StartCoroutine(SwitchScene());
        }*/ // NO LONGER USED - scene switch via maxScore is handled by Gun.cs

        if (Input.GetKeyDown(KeyCode.Return) && SceneManager.GetActiveScene().buildIndex != 8)
        {
            print("enter key was pressed - loading tutorial scene");
            print("Leaving Scene " + SceneManager.GetActiveScene().buildIndex.ToString()); // outputs the scene number
            print("Entering Tutorial Scene");
            SceneManager.LoadScene(8);
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && SceneManager.GetActiveScene().buildIndex == 8)
        {
            print("Backspace key was pressed - loading next scene");
            print("Leaving Tutorial Scene "); // outputs the scene number
            print("Entering Dart Scene 0");
            Destroy(GameObject.Find("Player"));
            SceneManager.LoadScene(0);
        }
    }

    }
