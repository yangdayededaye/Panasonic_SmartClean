using Panasonic_SmartClean.Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panasonic_SmartClean
{
    public partial class FSelectType : UIForm
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public EWorkPieceType eType;

        public FSelectType()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);

        }

        private void FSelectType_Resize(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this.Width, this.Height, this);
        }

        private void btnSmall_Click(object sender, EventArgs e)
        {
            eType = EWorkPieceType.small;
        }

        private void btnBig_Click(object sender, EventArgs e)
        {
            eType = EWorkPieceType.big;
        }

        private void btnSuperBig_Click(object sender, EventArgs e)
        {
            eType = EWorkPieceType.superbig;
        }
    }
}
