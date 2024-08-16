using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPlacer : MonoBehaviour
{
    public PrefabList prefabList;
    public float scale;
    public RangeInt placeableRange = new(0, 4);
    public ScoreManager scoreManager;
    public GameObject placing;

    public bool PlaceNextPrefab(Vector3 pos, Sprite ourSprite)
    {
        // �v���n�u���X�g����A�X�v���C�g�̃C���f�b�N�X���擾
        var index = prefabList.entries.FindIndex(e => e.prefab.GetComponent<SpriteRenderer>().sprite == ourSprite);
        // �C���f�b�N�X���͈͂𒴂��Ă�����I��
        if (index < 0 || index >= prefabList.entries.Count - 1)
        {
            return false;
        }

        // ���̃C���f�b�N�X�̃v���n�u���擾
        var entry = prefabList.entries[index + 1];

        // �v���n�u��ݒu
        Place(entry, pos);

        // �X�R�A�����Z
        scoreManager.AddScore(entry.score);

        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �N���b�N�J�n
        if (Input.GetMouseButtonDown(0))
        {
            // �܂��̓����_���Œu�����̂����߂�
            var entry = prefabList.entries[Random.Range(placeableRange.start, placeableRange.end)];

            // �ʒu���N���b�N�ʒu�ɂ���
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            // �N���b�N���̕�������Ώ���
            if (placing != null)
            {
                Destroy(placing);
            }

            // �v���n�u��ݒu
            placing = Place(entry, pos);
            // ��U������OFF�ɂ���
            placing.GetComponent<Rigidbody2D>().simulated = false;
            placing.GetComponent<Collider2D>().enabled = false;
        }

        // �N���b�N��
        if (Input.GetMouseButton(0) && placing != null)
        {
            // �ʒu���N���b�N�ʒu�ɂ���
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            // �v���n�u���ړ�
            placing.transform.position = pos;
        }

        // �N���b�N�I��
        if (Input.GetMouseButtonUp(0) && placing != null)
        {
            // ��U������ON�ɂ���
            placing.GetComponent<Rigidbody2D>().simulated = true;
            placing.GetComponent<Collider2D>().enabled = true;
            // �v���n�u��null�ɂ���
            placing = null;
        }
    }

    // �v���n�u��ݒu����
    private GameObject Place(PrefabList.PrefabEntry entry, Vector3 pos)
    {
        // �v���n�u�𐶐�
        var obj = Instantiate(entry.prefab, transform);
        // �ʒu��ݒ�
        obj.transform.position = pos;
        // �傫����ݒ�
        obj.transform.localScale = Vector3.one * entry.size * scale;

        return obj;
    }
}
