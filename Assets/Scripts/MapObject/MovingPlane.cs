using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;

public class MovingPlane : MonoBehaviour
{

    private Rigidbody _rigidbody;

    public float speed;
    int sign;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        sign = -1;

        StartCoroutine(ChangeTargetPos());
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(sign*10, 3, 5),Time.deltaTime);

    }

    IEnumerator ChangeTargetPos()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            sign *= -1;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            ContactPoint contact = collision.GetContact(0);
            // 아래쪽, 옆쪽 충돌시 적용하지 않음
            if (contact.normal.y > -0.5f) return;

            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
