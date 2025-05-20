using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreProgram : MonoBehaviour
{
    [SerializeField] Text _score;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;
    int score = 0;
    public void MoleKill(int point)
    {
        score += point;
        _audioSource.PlayOneShot(_audioClip);
        _score.text = "Score:"+score;
    }
}
