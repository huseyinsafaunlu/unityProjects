using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        ScoreMenager.instance.AddPoint();
        Destroy(gameObject);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
