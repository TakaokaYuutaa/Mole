using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class MoleProgram : MonoBehaviour
{
    [SerializeField] Mole_InOut _inOut;
    void Start()
    {
        var _ = MoleAction();
    }
    void OnMouseDown()
    {
        _inOut.judgMolesOut[_inOut.holeNo] = false;
        Destroy(this.gameObject);
    }
    async UniTask MoleAction()
    {
        this.transform.DOMoveY(5, 0.8f).SetRelative();
        await UniTask.Delay(800);
        this.transform.DOMoveY(-5, 0.8f).SetRelative();
        Destroy(this.gameObject);
        _inOut.judgMolesOut[_inOut.holeNo] = false;
    }
}
