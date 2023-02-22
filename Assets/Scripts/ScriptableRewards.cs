using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "My Game/Rewards")]
public class ScriptableRewards : ScriptableObject
{
    public string bonusName;
    public float statsAdd;
    public Image image;
}
