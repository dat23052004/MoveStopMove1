using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Custom/LevelSO", order = 1)]
public class LevelDataSO : ScriptableObject
{
    public List<Level> listLevels;
}
