using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBehavior : MonoBehaviour
{
    PrefabPlacer prefabPlacer;

    // Start is called before the first frame update
    void Start()
    {
        // プレハブプレイサーを取得
        prefabPlacer = GetComponentInParent<PrefabPlacer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 自身のスプライト
        var ourSprite = GetComponent<SpriteRenderer>().sprite;
        // 衝突した相手のスプライト
        var theirSprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;

        // IDが大きい方のみ処理する
        if (gameObject.GetInstanceID() < collision.gameObject.GetInstanceID())
        {
            return;
        }

        // 同じプレハブ同士が衝突したら
        if (ourSprite == theirSprite)
        {
            // 間の位置を計算
            var pos = (transform.position + collision.transform.position) / 2;

            // 次のティアのプレハブを設置
            if (prefabPlacer.PlaceNextPrefab(pos, ourSprite))
            {
                // 次のティアのプレハブを設置できたら、このプレハブを消す

                // このプレハブを消す
                Destroy(gameObject);
                // 衝突した相手も消す
                Destroy(collision.gameObject);
            }
        }
    }
}
