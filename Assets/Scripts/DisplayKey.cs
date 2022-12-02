using System.Collections;
using System.Collections.Generic;
using ERC721Example.Contracts.ERC721Example.ContractDefinition;
using Godwoken;
using UnityEngine;
using UnityEngine.UI;

public class DisplayKey : MonoBehaviour
{
    public MetaMaskController metamaskController;

    public Image keyImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RefreshNFTImage()
    {
        metamaskController.GetExampleNFTs(ERC721ExampleDeployment.ADDRESS, UpdateSprite);
    }

    private void UpdateSprite(List<Sprite> sprites)
    {
        keyImage.sprite = sprites[sprites.Count - 1];
    }
}
