using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopAnim());
    }

    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

}
