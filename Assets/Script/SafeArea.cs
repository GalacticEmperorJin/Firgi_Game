using UnityEngine;
using UnityEngine.UIElements;

public class SafeArea : VisualElement
{
    // Unity 2022 requires this factory to expose the element to UXML / UI Builder
    public new class UxmlFactory : UxmlFactory<SafeArea, UxmlTraits> { }
    public new class UxmlTraits : VisualElement.UxmlTraits { }

    public SafeArea()
    {
        // Register the callback to wait for the panel to attach
        RegisterCallback<AttachToPanelEvent>(OnAttachToPanel);
    }

    private void OnAttachToPanel(AttachToPanelEvent evt)
    {
        if (panel != null)
        {
            panel.visualTree.RegisterCallback<GeometryChangedEvent>(UpdateGeometry);
        }
    }

    private void UpdateGeometry(GeometryChangedEvent evt)
    {
        if (panel == null)
            return;

#if UNITY_EDITOR
        if (panel.contextType == ContextType.Editor)
        {
            return;
        }
#endif

        Rect safeArea = Screen.safeArea;
        float screenHeight = (float)Screen.height;

        Vector2 safeAreaLeftTop = RuntimePanelUtils.ScreenToPanel(panel, new Vector2(safeArea.xMin, screenHeight - safeArea.yMax));
        Vector2 safeAreaRightBottom = RuntimePanelUtils.ScreenToPanel(panel, new Vector2(Screen.width - safeArea.xMax, safeArea.yMin));

        style.paddingLeft = safeAreaLeftTop.x;
        style.paddingTop = safeAreaLeftTop.y;
        style.paddingRight = safeAreaRightBottom.x;
        style.paddingBottom = safeAreaRightBottom.y;
    }
}
