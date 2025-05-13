using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class MoleProgram : MonoBehaviour
{
    [SerializeField] Mole_InOut _inOut;
    int moleholeNo;
    void Start()
    {
        moleholeNo = _inOut.holeNo;
        var _ = MoleAction();
    }
    void OnMouseDown()
    {
        _inOut.judgMolesOut[moleholeNo] = false;
        Destroy(this.gameObject);
    }
    async UniTask MoleAction()
    {
        this.transform.DOMoveY(5, 0.8f).SetRelative();
        await UniTask.Delay(3000);
        this.transform.DOMoveY(-5, 0.8f).SetRelative();
        await UniTask.Delay(800);
        _inOut.judgMolesOut[moleholeNo] = false;
        Destroy(this.gameObject);
    }
}
