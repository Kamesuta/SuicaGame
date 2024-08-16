using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabList", menuName = "ScriptableObjects/PrefabList", order = 1)]
public class PrefabList : ScriptableObject
{
    // オブジェクトの設定リスト
    public List<PrefabEntry> entries;

    // オブジェクトの設定
    [System.Serializable]
    public class PrefabEntry
    {
        public GameObject prefab;
        public float size;
        public int score;
    }
}
