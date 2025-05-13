using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MoleProgram : MonoBehaviour
{
    [SerializeField] Mole_InOut _inOut;
    void Start()
    {
       
    }
    void OnMouseDown()
    {
        _inOut.judgMolesOut[_inOut.holeNo] = false;
        Destroy(this);
    }
    async UniTask MoleAction()
    {

        await UniTask.Delay(800);
    }
}
