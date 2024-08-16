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
        // プレハブリストから、スプライトのインデックスを取得
        var index = prefabList.entries.FindIndex(e => e.prefab.GetComponent<SpriteRenderer>().sprite == ourSprite);
        // インデックスが範囲を超えていたら終了
        if (index < 0 || index >= prefabList.entries.Count - 1)
        {
            return false;
        }

        // 次のインデックスのプレハブを取得
        var entry = prefabList.entries[index + 1];

        // プレハブを設置
        Place(entry, pos);

        // スコアを加算
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
        // クリック開始
        if (Input.GetMouseButtonDown(0))
        {
            // まずはランダムで置くものを決める
            var entry = prefabList.entries[Random.Range(placeableRange.start, placeableRange.end)];

            // 位置をクリック位置にする
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            // クリック中の物があれば消す
            if (placing != null)
            {
                Destroy(placing);
            }

            // プレハブを設置
            placing = Place(entry, pos);
            // 一旦物理をOFFにする
            placing.GetComponent<Rigidbody2D>().simulated = false;
            placing.GetComponent<Collider2D>().enabled = false;
        }

        // クリック中
        if (Input.GetMouseButton(0) && placing != null)
        {
            // 位置をクリック位置にする
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            // プレハブを移動
            placing.transform.position = pos;
        }

        // クリック終了
        if (Input.GetMouseButtonUp(0) && placing != null)
        {
            // 一旦物理をONにする
            placing.GetComponent<Rigidbody2D>().simulated = true;
            placing.GetComponent<Collider2D>().enabled = true;
            // プレハブをnullにする
            placing = null;
        }
    }

    // プレハブを設置する
    private GameObject Place(PrefabList.PrefabEntry entry, Vector3 pos)
    {
        // プレハブを生成
        var obj = Instantiate(entry.prefab, transform);
        // 位置を設定
        obj.transform.position = pos;
        // 大きさを設定
        obj.transform.localScale = Vector3.one * entry.size * scale;

        return obj;
    }
}
