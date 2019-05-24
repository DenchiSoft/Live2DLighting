using System.Linq;
using Live2D.Cubism.Core;
using Live2D.Cubism.Rendering;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Replace active Live2D model texture temporarily
/// at runtime or permanently in editor.
/// </summary>
public class CubismTextureReplacer : MonoBehaviour
{
    public CubismModel model;
    public Texture2D newTexture;

#if UNITY_EDITOR
    [CustomEditor(typeof(CubismTextureReplacer))]
    public class LauncherEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var textureReplacer = target as CubismTextureReplacer;

            if (textureReplacer != null && GUILayout.Button("Replace model texture"))
            {
                textureReplacer.Reload();
            }
        }
    }
#endif

    public void Reload()
    {
        if (model != null)
        {
            if (newTexture != null) { 
                foreach (var drawable in model.Drawables.ToList())
                {
                    CubismRenderer r = drawable.gameObject.GetComponent<CubismRenderer>();

                    if (r != null) { 
                        r.MainTexture = newTexture;
                    }
                }

                Debug.Log("Replaced texture for model \"" + model.name + "\" (" + model.Drawables.Length + " drawables).");
            }
            else
            {
                Debug.Log("Set replacement texture first.");
            }
        }
        else
        {
            Debug.Log("Set model first.");
        }
    }
}
