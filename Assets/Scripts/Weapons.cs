using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform leftHand;
    public GameObject arrow;
    public Transform arrowSocketPoint;

    public void reloadArrow()
    {
        if (Vector3.Distance(Camera.main.transform.position, leftHand.position) < 1 && leftHand.position.x < 0)
        {
            GameObject.Instantiate(arrow, leftHand.position,Quaternion.identity);
        }
    }
    public void fireArrow()
    {
        arrowSocketPoint.GetChild(0).transform.Translate(Vector3.forward);
    }
}
