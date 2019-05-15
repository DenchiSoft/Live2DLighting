using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework.Physics;

namespace Live2D.Cubism.Viewer.Gems.Misc
{
    /// <summary>
    /// Makes the character look towards the mouse pointer when you press ALT + the left mouse button.
    /// </summary>
    public sealed class LookAround : MonoBehaviour
    {
        // Percentage of the screen that gets cut off when tracking the mouse.
        // Cut off outer 10%, this means tracking only uses the inner 90%.
        private const float screenCutOff = 0.1f;

        // Parameters the character uses for opening/closing mouth.
        private string[] mouthParams = { "ParamMouthOpenY", "ParamMouthOpen", "PARAM_MOUTH_OPEN_Y" };

        // The model to control.
        private CubismModel model;

        // Fading stuff.
        public float smoothTime = 0.01F;
        private Vector2 velocity = Vector2.zero;
        private Vector2 lastPos = Vector2.zero;

        // List of all parameter names that can be tracked and their usual min/max.
        private readonly string[] paramNames =
        {
            "ParamAngleX",		// -30 to 30
			"ParamAngleY",		// -30 to 30
			"ParamAngleZ",		// -30 to 30
			"ParamBodyAngleX",	// -10 to 10
			"ParamBodyAngleZ",	// -10 to 10
			"ParamEyeBallX",	// -1  to 1
			"ParamEyeBallY",	// -1  to 1
			"CatEyeX",			// -1  to 1
			"CatEyeY"			// -1  to 1
		};

        // List of all trackable parameters that were found in the model.
        private List<CubismParameter> CubismParams;

        /// <summary>
        /// Called by Unity. Initializes instance.
        /// </summary>
        void Start()
        {
            // Get model.
            model = gameObject.GetComponent<CubismModel>();
            if (model == null)
            {
                model = gameObject.GetComponentInChildren<CubismModel>();
            }

            // BUG: Live2D physics will not work if it's enabled from the beginning.
            model.GetComponent<CubismPhysicsController>().enabled = true;

            // Find all trackable parameters in model.
            CubismParams = new List<CubismParameter>();

            foreach (CubismParameter p in model.Parameters)
            {
                foreach (string name in paramNames)
                {
                    if (p.Id == name)
                    {
                        CubismParams.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the model drag position.
        /// </summary>
        /// <param name="dragStarted">True if drag operation has started.</param>
        /// <returns>The mouse position in percent of the screen (between 0 and 1).</returns>
        private Vector2 CalculateDragPosition(bool dragStarted)
        {
            // Remove top, bottom, left and right 10% of the screen and calculate position in the resulting rectangle in percent.
            float minScreen = screenCutOff;
            float maxScreen = 1 - 2 * minScreen;
            float mousePosX = Mathf.Clamp(Input.mousePosition.x - Screen.width * minScreen, 0, maxScreen * Screen.width) / (Screen.width * maxScreen);
            float mousePosY = Mathf.Clamp(Input.mousePosition.y - Screen.height * minScreen, 0, maxScreen * Screen.height) / (Screen.height * maxScreen);

            // Smooth movement.
            Vector2 mousePos = new Vector2(mousePosX, mousePosY);
            lastPos = dragStarted ? mousePos : Vector2.SmoothDamp(lastPos, mousePos, ref velocity, smoothTime);

            return lastPos;
        }

        /// <summary>
        /// Called by Unity. Updates character.
        /// </summary>
        void LateUpdate()
        {
            if (CubismParams == null || CubismParams.Count == 0)
                return;

            if (Input.GetMouseButton(0))
            {
                Vector2 pos = CalculateDragPosition(Input.GetMouseButtonDown(0));

                // Set parameters accordingly.
                // Parameters like "ParamAngleX" that end in "X" are considered to be controlled by the x position of the cursor, etc.
                foreach (CubismParameter p in CubismParams)
                {
                    if (p.Id.EndsWith("X") || p.Id.EndsWith("ParamAngleZ") || p.Id.EndsWith("ParamBodyAngleZ"))
                    {
                        p.Value = Mathf.Lerp(p.MinimumValue, p.MaximumValue, pos.x);
                    }
                    else if (p.Id.EndsWith("Y") && !mouthParams.Contains(p.Id))
                    {
                        p.Value = Mathf.Lerp(p.MinimumValue, p.MaximumValue, pos.y);
                    }
                }
            }
        }
    }
}