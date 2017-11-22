using System;
namespace Simedia.App.SDK
{
    public class ActionResult
    {
        public ActionResult()
        {
        }

        public virtual bool success
        {
            get;
            set;
        }

        public virtual string message
        {
            get;
            set;
        }
    }
}
