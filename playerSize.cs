using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSize : MonoBehaviour
{
    // Update is called once per frame
    public static playerSize instance;

    Vector3 previousSize = new Vector3();
    private void Awake()
    {
        instance = this;
    }


    void Update()
    {




    }
    
    public void reSize()
    {
        
        if (this.gameObject.transform.localScale.y >= 0.3f && this.gameObject.transform.localScale.y<=1.5f)
        {
            previousSize = this.gameObject.transform.localScale;
            this.gameObject.transform.localScale += new Vector3(-touchPad.instance.sizeY, touchPad.instance.sizeY, 0);

        }
        else if(this.gameObject.transform.localScale.y < 0.3f)
        {
            this.gameObject.transform.localScale = new Vector3(previousSize.x, 0.3f, previousSize.z);
        }
        else if (this.gameObject.transform.localScale.y > 1.5f)
        {
            this.gameObject.transform.localScale = new Vector3(previousSize.x, 1.5f, previousSize.z);
        }



        //previousSize = this.gameObject.transform.localScale;

    }


}
