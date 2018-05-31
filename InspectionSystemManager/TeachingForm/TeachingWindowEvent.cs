using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;

using ParameterManager;

namespace InspectionSystemManager
{
    public partial class TeachingWindow
    {
        #region InitializeEvent & DeInitializeEvent
        private void InitializeEvent()
        {
            ucCogBlobReferWnd.ApplyBlobReferValueEvent += new ucCogBlobReference.ApplyBlobReferValueHandler(ApplyBlobReferenceValueFunction);
        }

        private void DeInitializeEvent()
        {
            ucCogBlobReferWnd.ApplyBlobReferValueEvent -= new ucCogBlobReference.ApplyBlobReferValueHandler(ApplyBlobReferenceValueFunction);
        }
        #endregion InitializeEvent & DeInitializeEvent


        #region Blob Reference Window Event : ucCogBlobReferenceWindow -> TeachingWindow
        private void ApplyBlobReferenceValueFunction(TeachParam.BlobReferTeachParam _ApplyParam, ref TeachParam.BlobReferTeachReturnParam _ReturnParam)
        {
            if (eTeachStep.ALGO_SET != CurrentTeachStep) { MessageBox.Show("Not select \"Algorithm Set\" button"); return; }
            AlgorithmAreaDisplayRefresh();


            CogBlobProcess.SetHardFixedThreshold(_ApplyParam.ThresholdMin);

            if (true == CogBlobProcess.Inspection(InspectionImage, AreaRegionRectangle))
                CogBlobProcess.GetResult(true);

            if (CogBlobProcess.GetResults().BlobCount > 0)
            {
                CogBlobReferenceResult _BlobResultParameter = new CogBlobReferenceResult();
                _BlobResultParameter = CogBlobProcess.GetResults();

                _ReturnParam.OriginX = _BlobResultParameter.BlobBoundCenterX[0];
                _ReturnParam.OriginY = _BlobResultParameter.BlobBoundCenterY[0];
            }
        }
        #endregion Blob Reference Window Event : ucCogBlobReferenceWindow -> TeachingWindow
    }
}
