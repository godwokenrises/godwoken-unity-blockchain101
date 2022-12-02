using System.Collections;
using System.Collections.Generic;
using ERC721Example.Contracts.ERC721Example.ContractDefinition;
using Godwoken;
using UnityEngine;
using UnityEngine.UI;

public class MintKeyButtonController : MonoBehaviour
{
    public MetaMaskController metaMaskController;

    public DisplayKey displayKey;
    
    private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    
    // Called when the mint key button is clicked
    public void OnMintKeyButtonClicked()
    {
        button.interactable = false;
        StartCoroutine(MintKey());
    }


    private IEnumerator MintKey()
    {
        // 1. Create Unity to Godwoken Transaction
        var transaction = metaMaskController.UnityToGodwokenTransaction();
        if (transaction == null)
        {
            yield break;
        }
        
        // 2. Fill transaction with data including the function (mint) and parameters
        var mintFunction = new SafeMintFunction()
        {
            To = metaMaskController.GetAddress(),
            Uri = "https://my-json-server.typicode.com/godwokenrises/godwoken-unity-blockchain101/tokens"
        };

        // 3. Sign and send the transaction (user pays gas fees)
        yield return transaction.SignAndSendTransaction(mintFunction, ERC721ExampleDeployment.ADDRESS);

        // reactive button  
        button.interactable = true;

        yield return new WaitForSeconds(5f);
        
        displayKey.RefreshNFTImage();
    }
 
}
