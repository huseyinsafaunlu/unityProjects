using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="devide3")
        {
            arrowCounter.instance.arrowCount = arrowCounter.instance.arrowCount / 3;
            arrowCounter.instance.updateArrows();
        }

        if (other.tag == "multi2")
        {
            arrowCounter.instance.arrowCount = arrowCounter.instance.arrowCount * 2;
            arrowCounter.instance.updateArrows();
        }

        if (other.tag == "add50")
        {
            arrowCounter.instance.arrowCount = arrowCounter.instance.arrowCount + 50;
            arrowCounter.instance.updateArrows();
        }

        if (other.tag == "sub25")
        {
            arrowCounter.instance.arrowCount = arrowCounter.instance.arrowCount - 25;
            if (arrowCounter.instance.arrowCount<0)
            {
                arrowCounter.instance.arrowCount = 0;
            }
            arrowCounter.instance.updateArrows();
        }
    }
}
