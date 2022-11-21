using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    public GameObject muzzle;
    public GameObject Bullet;
    public float ShootInterval = 10f;
    IEnumerator ShootRoutine()
    {
        while (true)
        {
            Instantiate(Bullet, muzzle.transform.position, transform.rotation);
            yield return new WaitForSeconds(ShootInterval);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    Coroutine coroutine;

    // Update is called once per frame
    void Update()
    {
        //발사
        coroutine = StartCoroutine(ShootRoutine()); //코루틴을 시작
 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit info, 100, ~0);
        //Debug.Log(info.point);

        Quaternion rot = Quaternion.LookRotation(info.point - transform.position);
        Vector3 eulerRot = rot.eulerAngles;
        eulerRot.x = 0;
        eulerRot.z = 0;
        transform.rotation = Quaternion.Euler(eulerRot);
    }
}
