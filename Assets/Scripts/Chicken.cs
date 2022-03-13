using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chicken : MonoBehaviour
{
    public GameObject chickenVFX;
    
    private Rigidbody rigid;

    private void Start() 
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void DestroyChicken()
    {
        transform.parent = null;
        rigid.constraints = RigidbodyConstraints.None;
        rigid.isKinematic = false;
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1f);
        
        Instantiate(chickenVFX,transform.position,Quaternion.identity);

        Destroy(gameObject);
    }

    public void JumpChiken()
    {
        rigid.isKinematic = false;
        transform.DOLocalMove(transform.localPosition + Vector3.up,0.5f).SetEase(Ease.OutBack).SetLoops(-1, LoopType.Yoyo);
    }
}
