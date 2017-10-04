using System;
using UIKit;
using MBProgressHUD;

namespace HelloWorld.iOS.Services
{
    public class ProgressHUD
    {
        private MTMBProgressHUD _progress;
        private UIView _parent;
        private string _message;

        public ProgressHUD(UIView parent, string message)
        {
            _parent = parent;
            _message = message;
        }

        public ProgressHUD(UIView parent) : this(parent, "Loading...")
        {
        }

        public bool Visible
        {
            get { return _progress != null; }
            set
            {
                if (Visible == value)
                {
                    return;
                }
                if (value)
                {
                    _progress = new MTMBProgressHUD(_parent)
                    {
                        LabelText = _message,
                        RemoveFromSuperViewOnHide = true
                    };
                    _parent.AddSubview(_progress);
                    _progress.Show(true);
                }
                else
                {
                    _progress.Hide(true);
                    _progress = null;
                }
            }
        }
    }
}
