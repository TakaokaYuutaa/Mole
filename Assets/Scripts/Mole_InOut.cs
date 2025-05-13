using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Mole_InOut : MonoBehaviour
{
    [SerializeField] GameObject _mole;
    public int holeNo;
    public List<bool> judgMolesOut = new()
    {
        false, false, false, 
        false, false, false,
        false, false, false,
    };
    int timer = 60;
    float molesPostion = 9;
    bool gamePlay;
    private void Start()
    {
        var _ = TimerStart();
    }
    private void FixedUpdate()
    {
        var _ = RandomDelay();
    }
    async UniTask TimerStart()
    {
        gamePlay = true;
        await UniTask.Delay(timer * 1000);
        gamePlay = false;
    }
    async UniTask RandomDelay()
    {
        int delayTimeX = 50;
        int delayTimeY = 100;
        await UniTask.Delay(Random.Range(delayTimeX,delayTimeY) * 100);
        AdventMole(molesPostion);
    }
    void AdventMole(float molePos)
    {
        int holeCount = 3;
        if (gamePlay)
        {
            Vector2 position;
            position.x = Random.Range(0, holeCount) * molesPostion;
            position.y = Random.Range(0, holeCount) * molesPostion;
            _mole.gameObject.transform.position = new Vector3(position.x, -5, position.y);
            for (int i = 0; i < judgMolesOut.Count; i++)
            {
                if (position.x == molesPostion * (molesPostion%holeCount) && position.y == molesPostion * (molesPostion%holeCount) && judgMolesOut[i] == false)
                {
                    judgMolesOut[i] = true;
                    AddMole();
                    holeNo = i;
                }
            }
        }
    }
    void AddMole()
    {
        GameObject Mole = Instantiate(_mole);
        Mole.SetActive(true);
    }
}