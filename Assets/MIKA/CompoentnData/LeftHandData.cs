﻿using System;

namespace MIKA {
    public class LeftHandData : AComponentData {
        public LeftHandData(Func<float[]> fposition, Func<float[]> fRotation) : base(fposition, fRotation) { }
    }
}