using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject blow;
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("我穿过了" + collision.name);
        if (collision.gameObject.CompareTag("Head"))
        {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(50);
        }else if (collision.gameObject.CompareTag("Body"))
        {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(10);
        }
        else if (collision.gameObject.CompareTag("player"))
        {
            collision.gameObject.GetComponent<Hurt>().gethurt(1);
        }

        GameObject clone;
        Vector3 v = new Vector3(0.0f,1.0f, -1.0f);
        clone = (GameObject)Instantiate(blow, collision.transform.position+v, this.transform.rotation);

        Destroy(clone, 1.0f);

        Destroy(this.gameObject);
    }
}
