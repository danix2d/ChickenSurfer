using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Control control;

    public GameObject cubeVFX;

    public Rigidbody rigid;

    private bool hasChecked;

    private void Update() {
        if(transform.parent == null)
        {
            rigid.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other) {

        if(!hasChecked && other.gameObject.CompareTag("Enemy"))
        {
            hasChecked = true;

            control.enableRigid = true;
            control.checkNumStack = true;

            gameObject.transform.parent = null;
            
            StartCoroutine(WaitTime(0.3f));
        }
    }


    private IEnumerator WaitTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(cubeVFX,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}
