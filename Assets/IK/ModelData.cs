﻿namespace ModularIK {
    class ModelData {
        private float[] headPosition = new float[3];
        private float[] headRotation = new float[3];
        private float[] leftFootPosition = new float[3];
        private float[] leftFootRotation = new float[3];
        private float[] rightFootPosition = new float[3];
        private float[] rightFootRotation = new float[3];

        public float[] HeadPosition
        {
            get
            {
                return headPosition;
            }
        }
        public float[] HeadRotation
        {
            get
            {
                return headRotation;
            }
        }
        public float[] LeftFootPosition
        {
            get
            {
                return leftFootPosition;
            }
        }
        public float[] LeftFootRotation
        {
            get
            {
                return leftFootRotation;
            }
        }
        public float[] RightFootPosition
        {
            get
            {
                return rightFootPosition;
            }
        }
        public float[] RightFootRotation
        {
            get
            {
                return rightFootRotation;
            }
        }



        void Test() {

        }
    }
}
