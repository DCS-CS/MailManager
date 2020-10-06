using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailManager.Components
{
    class ProfileMailsPanel : AdvancedMailsPanel
    {
        public CheckBox ChkSelect { get; set; }

        public ProfileMailsPanel()
        {
            ChkSelect = new CheckBox();
            Controls.Add(ChkSelect);
            //
            //  ChkSelect
            // 
            this.ChkSelect.AutoSize = true;
            this.ChkSelect.Location = new System.Drawing.Point(686, 25);
            this.ChkSelect.Name = "chkSelect";
            this.ChkSelect.Size = new System.Drawing.Size(136, 21);
            this.ChkSelect.TabIndex = 6;
            this.ChkSelect.UseVisualStyleBackColor = true;
        }
    }
}
