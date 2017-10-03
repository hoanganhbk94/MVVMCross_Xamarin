// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace HelloWorld.iOS
{
    [Register ("TipView")]
    partial class TipView
    {
        [Outlet]
        UIKit.UIButton BillButton { get; set; }


        [Outlet]
        UIKit.UISlider GenerositySlider { get; set; }


        [Outlet]
        UIKit.UITextField SubTotalTextField { get; set; }


        [Outlet]
        UIKit.UILabel TipLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BillButton != null) {
                BillButton.Dispose ();
                BillButton = null;
            }

            if (GenerositySlider != null) {
                GenerositySlider.Dispose ();
                GenerositySlider = null;
            }

            if (SubTotalTextField != null) {
                SubTotalTextField.Dispose ();
                SubTotalTextField = null;
            }

            if (TipLabel != null) {
                TipLabel.Dispose ();
                TipLabel = null;
            }
        }
    }
}