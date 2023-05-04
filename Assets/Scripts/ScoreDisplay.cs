using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI mText;


    // Start is called before the first frame update
    void Start()
    {
        mText.text = "Round #" + Gun.round.ToString() + " Score: " + CollisionBullet.totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = "Round #" + Gun.round.ToString() + " Score: " + CollisionBullet.totalScore.ToString();
    }
}
