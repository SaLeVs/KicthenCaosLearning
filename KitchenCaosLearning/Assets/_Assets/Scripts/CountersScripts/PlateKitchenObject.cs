using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList = new List<KitchenObjectSO>();

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        // add ingredient to the plate
        
        if(!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // ingredient is not valid
            return false;
        }
        
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // ingredient is already on the plate
            return false;
        }
        else
        {
            // ingredient is not on the plate
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
    }
}
