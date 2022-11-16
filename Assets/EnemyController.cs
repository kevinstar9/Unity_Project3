using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float followSpeed;
    public float Enemy_Damage;
    public float Max_HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return;
        }

        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();
        transform.position += diff * followSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
            Debug.Log(Max_HP -= Enemy_Damage);
            if (Max_HP <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
