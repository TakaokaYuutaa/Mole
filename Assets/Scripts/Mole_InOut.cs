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
    float molesPos = 9;
    bool gamePlay;
    private void Start()
    {
        var _ = TimerStart();
    }
    private void Update()
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
        AdventMole(molesPos);
    }
    void AdventMole(float molePos)
    {
        if (gamePlay)
        {
            Vector2 pos;
            pos.x = Random.Range(-1, 2) * molePos;
            pos.y = Random.Range(-1, 2) * molePos;
            _mole.gameObject.transform.position = new Vector3(pos.x, -5, pos.y);
            //‚Ç‚¤‚É‚©–@‘¥Œ©‚Â‚¯‚½‚¢«
            if (pos.x > 0 && pos.y > 0 && judgMolesOut[0] == false)
            {
                judgMolesOut[0] = true;
                AddMole();
                holeNo = 0;
            }
            if (pos.x == 0 && pos.y > 0 && judgMolesOut[1] == false)
            {
                judgMolesOut[1] = true;
                AddMole(); 
                holeNo = 1;
            }
            if (pos.x < 0 && pos.y > 0 && judgMolesOut[2] == false)
            {
                judgMolesOut[2] = true;
                AddMole();
                holeNo = 2;
            }
            if (pos.x > 0 && pos.y == 0 && judgMolesOut[3] == false)
            {
                judgMolesOut[3] = true;
                AddMole();
                holeNo = 3;
            }
            if (pos.x == 0 && pos.y == 0 && judgMolesOut[4] == false)
            {
                judgMolesOut[4] = true;
                AddMole();
                holeNo = 4;
            }
            if (pos.x < 0 && pos.y == 0 && judgMolesOut[5] == false)
            {
                judgMolesOut[5] = true;
                AddMole();
                holeNo = 5;
            }
            if (pos.x > 0 && pos.y < 0 && judgMolesOut[6] == false)
            {
                judgMolesOut[6] = true;
                AddMole();
                holeNo = 6;
            }
            if (pos.x == 0 && pos.y < 0 && judgMolesOut[7] == false)
            {
                judgMolesOut[7] = true;
                AddMole();
                holeNo = 7;
            }
            if (pos.x < 0 && pos.y < 0 && judgMolesOut[8] == false)
            {
                judgMolesOut[8] = true;
                AddMole();
                holeNo = 8;
            }
        }
    }
    void AddMole()
    {
        GameObject Mole = Instantiate(_mole);
        Mole.SetActive(true);
    }
}