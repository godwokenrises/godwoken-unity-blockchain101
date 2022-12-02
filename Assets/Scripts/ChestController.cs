using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private bool isOpen;
    private Animator chestAnimator;
    
    void Start()
    {
        isOpen = false;
        chestAnimator = GetComponent<Animator>();
    }

    // called when we have an NFT key
    public void OpenChest()
    {
        if (isOpen)
        {
            return;
        }

        isOpen = true;
        chestAnimator.Play("ChestOpen");
    }

    // called when we do not have an NFT key
    public void OpenChestFail()
    {
        chestAnimator.Play("ChestOpenFail");
    }
}
