using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowSocketPoint;

    public void reloadArrow()
    {
            GameObject.Instantiate(arrow, arrowSocketPoint.position,Quaternion.identity);
    }
    public void fireArrow()
    {
        arrowSocketPoint.GetChild(0).transform.Translate(Vector3.forward);
    }
}
