using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUpType { GoldCoin,Bubble};

public class PickUpComponent : MonoBehaviour
{
    [SerializeField]
    public PickUpType pickUpType;
}
