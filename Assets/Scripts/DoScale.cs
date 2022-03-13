using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoScale : MonoBehaviour
{
    public float duration;
    public float delay;
    public Ease ease;
    public Vector3 scale;
    public GameEvent gameEvent;
    [Range(0,2)]
    public float scaleValue;

    private Tween tween;

    public void DoAnim()
    {
        tween.Kill();
        transform.localScale = Vector3.one * scaleValue;
        tween = transform.DOScale(scale,duration).SetEase(ease).OnComplete(RaiseEvent);
    }

    private void RaiseEvent()
    {
        transform.localScale = Vector3.one;

        if(gameEvent == null){return;}

        gameEvent.Raise();
    }
}
