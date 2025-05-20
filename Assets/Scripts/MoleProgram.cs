using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MoleProgram : MonoBehaviour
{
    [SerializeField] Mole_InOut _inOut;
    [SerializeField] ScoreProgram _score;
    int moleholeNo;
    int moleKillPoint = 100;
    void Start()
    {
        var ct = this.GetCancellationTokenOnDestroy();
        moleholeNo = _inOut.holeNo;
        var _ = MoleAction(ct);
    }
    void OnMouseDown()
    {
        if (_inOut.gamePlay)
        {
            _inOut.judgMolesOut[moleholeNo] = false;
            _score.MoleKill(moleKillPoint);
            Destroy(this.gameObject);
        }
    }
    async UniTask MoleAction(CancellationToken cancel)
    {
        float moveTime = 0.8f;
        int inTimer = 3, outTimer = 8, inMagnification = 1000, outMagnification = 100;
        this.transform.DOMoveY(5, moveTime).SetRelative();
        await UniTask.Delay(inTimer*inMagnification, cancellationToken: cancel);
        this.transform.DOMoveY(-5, moveTime).SetRelative();
        await UniTask.Delay(outTimer*outMagnification, cancellationToken: cancel);
        _inOut.judgMolesOut[moleholeNo] = false;
        Destroy(this.gameObject);
    }
}
