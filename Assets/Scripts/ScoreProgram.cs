using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreProgram : MonoBehaviour
{
    [SerializeField] Text _score;
    int score = 0;
    public void MoleKill(int point)
    {
        score += point;
        _score.text = "Score:"+score;
    }
}
