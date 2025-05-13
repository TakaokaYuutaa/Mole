using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Mole_InOut : MonoBehaviour
{
    [SerializeField] GameObject _mole;
    public List<bool> judgMolesOut = new()
    {
        false, false, false, 
        false, false, false,
        false, false, false,
    };
    int timer = 60;
    int holeNo;
    float molesPos = 9;
    bool gamePlay;
    private void Start()
    {
        var _ = TimerStart();
    }
    private void Update()
    {
        AdventMole(molesPos);
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
        await UniTask.Delay(Random.Range(3, 15) * 100);
    }
    void AdventMole(float molePos)
    {
        if (gamePlay)
        {
            Vector2 pos;
            pos.x = Random.Range(-1, 1) * molePos;
            pos.y = Random.Range(-1, 1) * molePos;
            _mole.gameObject.transform.position = new Vector3(pos.x, -5, pos.y);
            GameObject Mole = Instantiate(_mole);
            if (pos.x > 0 && pos.y > 0 && judgMolesOut[0] == false)
            {
                judgMolesOut[0] = true;
                holeNo = 0;
            }
            if (pos.x == 0 && pos.y > 0 && judgMolesOut[1] == false)
            {
                judgMolesOut[1] = true;
                holeNo = 1;
            }
            if (pos.x < 0 && pos.y > 0 && judgMolesOut[2] == false)
            {
                judgMolesOut[2] = true;
                holeNo = 2;
            }
            if (pos.x > 0 && pos.y == 0 && judgMolesOut[3] == false)
            {
                judgMolesOut[3] = true;
                holeNo = 3;
            }
            if (pos.x == 0 && pos.y == 0 && judgMolesOut[4] == false)
            {
                judgMolesOut[4] = true;
                holeNo = 4;
            }
            if (pos.x < 0 && pos.y == 0 && judgMolesOut[5] == false)
            {
                judgMolesOut[5] = true;
                holeNo = 5;
            }
            if (pos.x > 0 && pos.y < 0 && judgMolesOut[6] == false)
            {
                judgMolesOut[6] = true;
                holeNo = 6;
            }
            if (pos.x == 0 && pos.y < 0 && judgMolesOut[7] == false)
            {
                judgMolesOut[7] = true;
                holeNo = 7;
            }
            if (pos.x < 0 && pos.y < 0 && judgMolesOut[8] == false)
            {
                judgMolesOut[8] = true;
                holeNo = 8;
            }
        }
    }
}