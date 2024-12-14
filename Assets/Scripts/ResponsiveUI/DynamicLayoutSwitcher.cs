using UnityEngine;
using UnityEngine.UI;

public class DynamicLayoutSwitcher : MonoBehaviour
{
    private RectTransform rectTransform;
    private LayoutGroup currentLayoutGroup;

    // Configuration for layouts
    [SerializeField] private float spacing = 10f;
    [SerializeField] private TextAnchor alignment = TextAnchor.UpperCenter;
    [SerializeField] private float aspectRatioThreshold=0.5f;

    void Start()
    {
        if(TryGetComponent(out VerticalLayoutGroup vcomponent))
        {
            currentLayoutGroup = vcomponent;
        }

        else if (TryGetComponent(out HorizontalLayoutGroup hcomponent))
        {
            currentLayoutGroup = hcomponent;
        }
        rectTransform = GetComponent<RectTransform>();
        UpdateLayout(); // Initial setup
    }

    void Update()
    {
        UpdateLayout();
    }

    void UpdateLayout()
    {
        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;

        // Calculate the aspect ratio (width / height)
        float aspectRatio = width / height;

        if (aspectRatio > aspectRatioThreshold && !(currentLayoutGroup is HorizontalLayoutGroup))
        {
            SwitchToHorizontalLayout();
        }
        else if (aspectRatio <= aspectRatioThreshold && !(currentLayoutGroup is VerticalLayoutGroup))
        {
            SwitchToVerticalLayout();
        }
    }

    void SwitchToHorizontalLayout()
    {
        DestroyCurrentLayoutGroup();
        HorizontalLayoutGroup horizontalLayout = gameObject.AddComponent<HorizontalLayoutGroup>();
        horizontalLayout.spacing = spacing;
        horizontalLayout.childAlignment = alignment;
        horizontalLayout.childForceExpandHeight = true;

        currentLayoutGroup = horizontalLayout;
        Debug.Log("Switched to Horizontal Layout");
    }

    void SwitchToVerticalLayout()
    {
        DestroyCurrentLayoutGroup();
        VerticalLayoutGroup verticalLayout = gameObject.AddComponent<VerticalLayoutGroup>();
        verticalLayout.spacing = spacing;
        verticalLayout.childAlignment = alignment;
        verticalLayout.childForceExpandHeight = true;

        currentLayoutGroup = verticalLayout;
        Debug.Log("Switched to Vertical Layout");
    }

    void DestroyCurrentLayoutGroup()
    {
        if (currentLayoutGroup != null)
        {
            DestroyImmediate (currentLayoutGroup);
        }
    }
}
