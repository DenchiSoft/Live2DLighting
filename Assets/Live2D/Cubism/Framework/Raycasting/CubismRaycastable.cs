﻿/*
 * Copyright(c) Live2D Inc. All rights reserved.
 * 
 * Use of this source code is governed by the Live2D Open Software license
 * that can be found at http://live2d.com/eula/live2d-open-software-license-agreement_en.html.
 */


using UnityEngine;


namespace Live2D.Cubism.Framework.Raycasting
{
    /// <summary>
    /// Allows raycasting against <see cref="Core.CubismDrawable"/>s.
    /// </summary>
    public sealed class CubismRaycastable : MonoBehaviour
    {
        /// <summary>
        /// The precision.
        /// </summary>
        public CubismRaycastablePrecision Precision;
    }
}
