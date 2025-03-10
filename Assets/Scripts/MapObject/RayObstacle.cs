using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RayObstacle : MonoBehaviour
{

    public float maxDistance;
    LayerMask mask;

    LineRenderer lineRenderer;

    private void Start()
    {
        mask = 1 << LayerMask.NameToLayer("Player");
        lineRenderer=GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,maxDistance, mask))
        {
            // �̺�Ʈ �߻�
            Debug.Log("���� �浹");
            transform.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.white;

        }
    }

}
