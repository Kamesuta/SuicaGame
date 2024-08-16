using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBehavior : MonoBehaviour
{
    PrefabPlacer prefabPlacer;

    // Start is called before the first frame update
    void Start()
    {
        // �v���n�u�v���C�T�[���擾
        prefabPlacer = GetComponentInParent<PrefabPlacer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���g�̃X�v���C�g
        var ourSprite = GetComponent<SpriteRenderer>().sprite;
        // �Փ˂�������̃X�v���C�g
        var theirSprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;

        // ID���傫�����̂ݏ�������
        if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
        {
            return;
        }

        // �����v���n�u���m���Փ˂�����
        if (ourSprite == theirSprite)
        {
            // �Ԃ̈ʒu���v�Z
            var pos = (transform.position + collision.transform.position) / 2;

            // ���̃e�B�A�̃v���n�u��ݒu
            if (prefabPlacer.PlaceNextPrefab(pos, ourSprite))
            {
                // ���̃e�B�A�̃v���n�u��ݒu�ł�����A���̃v���n�u������

                // ���̃v���n�u������
                Destroy(gameObject);
                // �Փ˂������������
                Destroy(collision.gameObject);
            }
        }
    }
}
