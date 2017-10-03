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
    [Register ("UserTableViewCell")]
    partial class UserTableViewCell
    {
        [Outlet]
        UIKit.UILabel EmailLabel { get; set; }


        [Outlet]
        UIKit.UILabel PasswordLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EmailLabel != null) {
                EmailLabel.Dispose ();
                EmailLabel = null;
            }

            if (PasswordLabel != null) {
                PasswordLabel.Dispose ();
                PasswordLabel = null;
            }
        }
    }
}