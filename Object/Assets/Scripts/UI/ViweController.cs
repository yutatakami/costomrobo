using UnityEngine;

[RequireComponent(typeof(RectTransform))]   // RectTransformコンポーネントを必須する
public class ViweController : MonoBehaviour
{
    // RectTransformコンポーネントをキャッシュ
    private RectTransform cachedRectTransform;
    public RectTransform CachedRectTransform
    {
        get {
            if (cachedRectTransform == null) {
                cachedRectTransform = GetComponent<RectTransform>();
            }
            return cachedRectTransform;
        }
    }

    // ビューのタイトルを取得、設定するプロパティ
    public virtual string Title { get { return ""; } set { } }
}
