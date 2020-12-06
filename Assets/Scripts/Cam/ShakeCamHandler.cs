using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamHandler : MonoBehaviour
{
    static Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public static void Shake()
    {
        anim.Play("ShakeCam");
        anim.ResetTrigger("Shake");
    }
}
