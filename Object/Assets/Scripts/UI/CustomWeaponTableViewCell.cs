using UnityEngine;
using UnityEngine.UI;

// リスト項目のデータクラスを定義
public class CustomWeponData
{
    public string iconName;     // アイコン名
    public string name;         // アイテム名
    public string description;  // 説明
}

public class CustomWeaponTableViewCell : TableViewCell<CustomWeponData>
{
    [SerializeField]
    Image iconImage;    // アイコンを表示するイメージ
    [SerializeField]
    Text nameLabel;     // アイテム名を表示するテキスト

    // セルの内容を更新するメゾットのオーバーライド
    public override void UpdateContent (CustomWeponData itemData)
    {
        nameLabel.text = itemData.name;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
