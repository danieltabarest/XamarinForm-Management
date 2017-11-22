using System;
using Xamarin.Forms;

namespace Acute.PageModels.Base
{
    public abstract class BaseModalPageModel : BasePageModel
    {

        public Command CloseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await PopModalAsync();
                });
            }
        }
    }
}
