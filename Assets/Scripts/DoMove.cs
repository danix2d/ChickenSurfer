using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoMove : MonoBehaviour
{
    public float duration;
    public float delay;
    public Vector3 goTo;
    public Ease ease;

    private void OnEnable() 
    {
        DoAnim();
    }

    public void DoAnim()
    {
        transform.DOLocalMove(goTo,duration).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
    }
}
