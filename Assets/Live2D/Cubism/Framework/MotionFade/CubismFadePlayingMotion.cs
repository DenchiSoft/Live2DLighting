﻿/*
 * Copyright(c) Live2D Inc. All rights reserved.
 * 
 * Use of this source code is governed by the Live2D Open Software license
 * that can be found at http://live2d.com/eula/live2d-open-software-license-agreement_en.html.
 */


using UnityEngine;


namespace Live2D.Cubism.Framework.MotionFade
{
    public struct CubismFadePlayingMotion
    {
        /// <summary>
        /// Animation clip start time.
        /// </summary>
        [SerializeField]
        public float StartTime;

        /// <summary>
        /// Animation clip end time.
        /// </summary>
        [SerializeField]
        public float EndTime;

        /// <summary>
        /// Cubism fade in start time.
        /// </summary>
        [SerializeField]
        public float FadeInStartTime;

        /// <summary>
        /// Animation playing speed.
        /// </summary>
        [SerializeField, Range(0.0f, float.MaxValue)]
        public float Speed;

        /// <summary>
        /// Cubism fade motion data.
        /// </summary>
        [SerializeField]
        public CubismFadeMotionData Motion;
    }
}