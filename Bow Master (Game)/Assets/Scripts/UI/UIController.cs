using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class UIController : MonoBehaviour {

    public Animator UIAnim;
    
    private bool stopper;

    void Start() {
        stopper = true;
        UIAnim = GetComponent<Animator>();
    }

    void Update() {
        if (GameManager.instance.bossDead && stopper) {
            UIAnim.SetTrigger("PlayerWin");
            stopper = false;
        }
    }

}
