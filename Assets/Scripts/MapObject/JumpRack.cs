using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<PlayerController>().IsGround())
            {
                return;
            }
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                Debug.Log(collision.contacts[i].point);
            }
            collision.rigidbody.AddForce(Vector3.up * 200,ForceMode.Impulse);

        }
    }
}
