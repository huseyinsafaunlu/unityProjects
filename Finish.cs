using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] ParticleSystem winParticle;
    [SerializeField] Transform cameraTransform;


    private void OnTriggerEnter(Collider other)
    {
        Handheld.Vibrate();
        Handheld.Vibrate();
        if (GeneralControl.instance.collectibleNumber == 0)
        {
            GeneralControl.instance.gameLose();
        }
        else if(GeneralControl.instance.collectibleNumber > 0)
        {
            GeneralControl.instance.gameWin();
            winParticle.Play();
        }
        
        GeneralControl.instance.stopMoving();

    }
}
