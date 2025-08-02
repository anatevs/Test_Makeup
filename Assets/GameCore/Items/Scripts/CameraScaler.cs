using UnityEngine;

namespace GameCore
{
    public static class CameraScaler
    {
        private static readonly int _defaultWidth = 1440;

        private static readonly float _scaleCoef =
            (float)Camera.main.pixelWidth / _defaultWidth;

        public static float ScaleWithCamera(float value)
        {
            return _scaleCoef * value;
        }
    }
}