using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ResourceManager 
{
    public AsyncOperationHandle Handle;
    private GameObject testObject;
    public int a = 10;
    void Start()
    {
        //LoadAddressable("Test");
        //Addressables.InstantiateAsync("Test");
        
    }



    public void LoadAddressable(string path)
    {
        Addressables.LoadAssetAsync<GameObject>(path).Completed +=
            (AsyncOperationHandle<GameObject> obj) =>
            {
                Handle = obj;
                Debug.Log(Handle.Result);
            };
    }

    public void ReleaseAddressable()
    {
        Addressables.Release(Handle);
    }
}
