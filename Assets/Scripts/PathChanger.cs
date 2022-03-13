using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathChanger : MonoBehaviour
{
    public PathCreator enterPath;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PathFollower>().pathCreator = enterPath;
        }
    }
}
