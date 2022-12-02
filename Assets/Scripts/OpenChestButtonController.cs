using System.Collections;
using System.Collections.Generic;
using ERC721Example.Contracts.ERC721Example.ContractDefinition;
using Godwoken;
using UnityEngine;
using UnityEngine.UI;

public class OpenChestButtonController : MonoBehaviour
{
    public MetaMaskController metaMaskControlller;
    public ChestController chestController;

    private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Called when the button is clicked
    public void OnChestButtonClicked()
    {
        button.interactable = false;
        metaMaskControlller.GetNumberOfExampleNFTs(ERC721ExampleDeployment.ADDRESS, OpenChestIfNFTExists);
    }

    private void OpenChestIfNFTExists(int numberOfKeys)
    {
        if (numberOfKeys == 0)
        {
            chestController.OpenChestFail();
            button.interactable = true;
            return;
        }
        
        chestController.OpenChest();
    }
}
