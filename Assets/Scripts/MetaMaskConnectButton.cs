using System.Collections;
using System.Collections.Generic;
using ERC721Example.Contracts.ERC721Example.ContractDefinition;
using Godwoken;
using UnityEngine;

public class MetaMaskConnectButton : MonoBehaviour
{
    public MetaMaskController metamaskController;
    public GameObject canvas;
    
    void Start()
    {
        
    }

    public void MetaMaskConnect()
    {
        metamaskController.Initialize(OnMetamaskInitialized);
    }

    public void OnMetamaskInitialized(string address)
    {
        metamaskController.SetupContract(ERC721ExampleDeployment.HASH, OnContractSetupComplete);
    }

    public void OnContractSetupComplete(string contractAddress)
    {
        canvas.SetActive(false);
        Debug.Log("ADDRESS: " + contractAddress);
        ERC721ExampleDeployment.ADDRESS = contractAddress;
    }
}
