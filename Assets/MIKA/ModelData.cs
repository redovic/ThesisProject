﻿using System;
using System.Collections.Generic;

namespace MIKA {
    /// <summary>
    /// ModelData just provides all available and necessary data.
    /// Various DataProvider deliver this data.
    /// </summary>
    class ModelData {
        private List<AComponentData> providers = new List<AComponentData>();
        public List<AComponentData> Providers {
            get {
                return providers;
            }
        }

        private LeftFootData leftFoot;
        public LeftFootData LeftFoot {
            get {
                return leftFoot;
            }
        }
        private RightFootData rightFoot;
        public RightFootData RightFoot {
            get {
                return rightFoot;
            }
        }
        private HipData hipData;
        public HipData HipData {
            get {
                return hipData;
            }
        }
        private LeftHandData leftHand;
        public LeftHandData LeftHand {
            get {
                return leftHand;
            }
        }
        private RightHandData rightHand;
        public RightHandData RightHand {
            get {
                return rightHand;
            }
        }
        private HeadData headData;
        public HeadData HeadData {
            get {
                return headData;
            }
        }


        private float[] hipPosition = new float[3];
        private float[] hipRotation = new float[3];
        private float[] headPosition = new float[3];
        private float[] headRotation = new float[3];
        private float[] leftFootPosition = new float[3];
        private float[] leftFootRotation = new float[3];
        private float[] rightFootPosition = new float[3];
        private float[] rightFootRotation = new float[3];
        private float[] leftHandPosition = new float[3];
        private float[] leftHandRotation = new float[3];
        private float[] rightHandPosition = new float[3];
        private float[] rightHandRotation = new float[3];

        public float[] HipPosition {
            get {
                return hipPosition;
            }
        }
        public float[] HipRotation {
            get {
                return hipRotation;
            }
        }
        public float[] HeadPosition {
            get {
                return headPosition;
            }
        }
        public float[] HeadRotation {
            get {
                return headRotation;
            }
        }
        public float[] LeftFootPosition {
            get {
                return leftFootPosition;
            }
        }
        public float[] LeftFootRotation {
            get {
                return leftFootRotation;
            }
        }
        public float[] RightFootPosition {
            get {
                return rightFootPosition;
            }
        }
        public float[] RightFootRotation {
            get {
                return rightFootRotation;
            }
        }
        public float[] LeftHandPosition { get { return leftHandPosition; } }
        public float[] LeftHandRotation { get { return leftHandRotation; } }
        public float[] RightHandPosition { get { return rightHandPosition; } }
        public float[] RightHandRotation { get { return rightHandRotation; } }

        #region public
        public void AddProvider(AComponentData provider) {
            providers.Add(provider);
            if (provider is LeftFootData)
                leftFoot = (LeftFootData)provider;
            else if (provider is RightFootData)
                rightFoot = (RightFootData)provider;
            else if (provider is HipData)
                hipData = (HipData)provider;
            else if (provider is LeftHandData)
                leftHand = (LeftHandData)provider;
            else if (provider is RightHandData)
                rightHand = (RightHandData)provider;
            else if (provider is HeadData)
                headData = (HeadData)provider;
        }
        public void RemoveProvider(AComponentData provider) {
            providers.Remove(provider);
            if (provider is LeftFootData)
                leftFoot = null;
            else if (provider is RightFootData)
                rightFoot = null;
            else if (provider is HipData)
                hipData = null;
            else if (provider is LeftHandData)
                leftHand = null;
            else if (provider is RightHandData)
                rightHand = null;
            else if (provider is HeadData)
                headData = null;
        }

        public void Update() {
            foreach (AComponentData item in providers) {
                if (item is LeftFootData || item is RightFootData)
                    HandleFeet(item);
                if (item is HipData)
                    HandleHip(item);
                if (item is LeftHandData || item is RightHandData)
                    HandleHands(item);
                if (item is HeadData)
                    HandleHead(item);
            }
        }
        #endregion

        #region private
        private void HandleFeet(AComponentData foot) {
            if (foot == leftFoot) {
                leftFootPosition = foot.Position();
                leftFootRotation = foot.Rotation();
            }
            else {
                rightFootPosition = foot.Position();
                rightFootRotation = foot.Rotation();
            }
        }
        private void HandleHip(AComponentData hip) {
            hipPosition = hip.Position();
            hipRotation = hip.Rotation();
        }
        private void HandleHands(AComponentData hand) {
            if (hand == leftHand) {
                leftHandPosition = hand.Position();
                leftHandRotation = hand.Rotation();
            }
            else {
                rightHandPosition = hand.Position(); // rightHand.Position();
                rightHandRotation = hand.Rotation();
            }
        }
        private void HandleHead(AComponentData head) {
            headPosition = head.Position();
            headRotation = head.Rotation();
        }
        #endregion
    }
}