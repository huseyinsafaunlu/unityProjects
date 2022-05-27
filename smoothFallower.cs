using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothFallower : MonoBehaviour
{

     public Transform currentLeadTransform;
    [SerializeField] Mesh sphere;
    [SerializeField] Mesh capsule;
    //[SerializeField] Mesh mesh2;
    public void SetLeadTransform(Transform leadTransform) => currentLeadTransform = leadTransform;
    private float velocity = 0f;
    private float smoothTime = 0.1f;

    private void Update()
    {
        if (currentLeadTransform == null) return;
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, currentLeadTransform.position.x, ref velocity, smoothTime), transform.position.y, transform.position.z);
        if (gameObject.GetComponent<smoothFallower>().currentLeadTransform == null) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "collectible")
        {
            generalControl.instance.increaseSphereCount();
            generalControl.instance.fallow();
            Destroy(other.gameObject);
        }
    }


}
