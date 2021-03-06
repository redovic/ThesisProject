﻿using System;
using MIKA;
using UnityEngine;

/// <summary>
/// The IKModelController controls the IK-Model 
/// and gets all transformation data from the ModelDataManager.
/// 
/// Set this up to fit the needs of the IK-Avatar.
/// Functionality is controlled by implemented interfaces (IDataReceiver).
/// </summary>
class IKModelController :  ICenterReceiver, ILeftFootReceiver, IRightFootReceiver, ILeftHandReceiver, IRightHandReceiver, IHeadReceiver {
    private IModelDataManager modelDataManager;
    IKControl ikControl;

    public IKModelController(IModelDataManager mdm, IKControl ik) {
        modelDataManager = mdm;
        modelDataManager.SubscribeReceiver(this);

        AssignIKModel(ik);
    }
    #region private
    private void AssignIKModel(IKControl ikControl) {
        this.ikControl = ikControl;

        //if (this.ikControl == null)
        //    return;
        //ikBody = this.ikControl.transform;
    }

    // TODO: fix disposing - this is not a MonoBehaviour anymore
    private void OnDestroy() {
        modelDataManager.UnsubscribeReceiver(this);
    }
    #endregion

    void IDataReceiver.VectorData(float[] position, float[] rotation)
    {
        // TODO: get rid of this implementation
    }
    void ICenterReceiver.VectorData(float[] position, float[] rotation) {
        ikControl.SetPosition(new Vector3(position[0], position[1], position[2]));
        ikControl.SetRotation(Quaternion.LookRotation(new Vector3(rotation[0], rotation[1], rotation[2]), Vector3.up));
    }
    void ILeftFootReceiver.VectorData(float[] position, float[] rotation) {
        ikControl.leftFootPosition = new Vector3(position[0], position[1], position[2]);
        ikControl.rightFootRotation = Quaternion.LookRotation(new Vector3(rotation[0], rotation[1], rotation[2]), Vector3.up).eulerAngles;
    }
    void IRightFootReceiver.VectorData(float[] position, float[] rotation) {
        ikControl.rightFootPosition = new Vector3(position[0], position[1], position[2]);
        ikControl.leftFootRotation = Quaternion.LookRotation(new Vector3(rotation[0], rotation[1], rotation[2]), Vector3.up).eulerAngles;
    }
    void ILeftHandReceiver.VectorData(float[] position, float[] rotation) {
        ikControl.leftHandPosition = new Vector3(position[0], position[1], position[2]);
        ikControl.leftHandRotation = Quaternion.LookRotation(new Vector3(rotation[0], rotation[1], rotation[2]), Vector3.up).eulerAngles;
    }
    void IRightHandReceiver.VectorData(float[] position, float[] rotation) {
        ikControl.rightHandPosition = new Vector3(position[0], position[1], position[2]);
        ikControl.rightHandRotation = Quaternion.LookRotation(new Vector3(rotation[0], rotation[1], rotation[2]), Vector3.up).eulerAngles;
    }
    void IHeadReceiver.VectorData(float[] position, float[] rotation) {
        ikControl.lookAtTarget = new Vector3(position[0], position[1], position[2]);
    }
}