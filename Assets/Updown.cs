using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updown : MonoBehaviour
{
    public float speed = 20;
    public float IntervalMin = 0.5f;
    public float IntervalMax = 3;
    public GameObject HitEffect;

    bool statPopUp = true;
    Vector3 positionOrg, positionTarget;
    // Start is called before the first frame update
    void Start()
    {
        positionOrg = positionTarget = transform.position; 
    }

    float timeEtapsed = 0, timeNext = 0;

    // Update is called once per frame
    void Update()
    {
        timeEtapsed += Time.deltaTime;
        if (timeEtapsed > timeNext) 
        {
            timeEtapsed = 0;
            timeNext = Random.Range(IntervalMin, IntervalMax);
            statPopUp = !statPopUp;
        }
        /*if (statPopUp)
        {
            positionTarget.y = positionOrg.y;
        }
        else 
        {
            positionTarget.y = positionOrg.y - transform.localScale.y;
        }*/
        positionTarget.y = statPopUp ? positionOrg.y : positionOrg.y - transform.localScale.y;
        transform.position = Vector3.Lerp (transform.position, positionTarget, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ham")
        {
            statPopUp = false;
            if (HitEffect) 
            {
                GameObject effect = Instantiate (HitEffect, transform.position, Quaternion.identity);
            }
        }
    }
}
