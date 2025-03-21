using UnityEngine;

public interface IKitchenObjectParent 
{

    public Transform GetKitchenObjectFollowTransform();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void CleanKitchenObject();

    public bool HasKitchenObject();
    

}
