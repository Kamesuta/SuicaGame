using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabList", menuName = "ScriptableObjects/PrefabList", order = 1)]
public class PrefabList : ScriptableObject
{
    // �I�u�W�F�N�g�̐ݒ胊�X�g
    public List<PrefabEntry> entries;

    // �I�u�W�F�N�g�̐ݒ�
    [System.Serializable]
    public class PrefabEntry
    {
        public GameObject prefab;
        public float size;
        public int score;
    }
}
