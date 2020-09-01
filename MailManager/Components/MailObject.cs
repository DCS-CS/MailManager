namespace MailManager
{
    using MailKit;
    using MimeKit;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    internal class MailObject : Panel
    {
        public Label Subject { get; set; }
        public Label From { get; set; }
        public Label Date { get; set; }
        public CheckBox ChkSelect { get; set; }
        public UniqueId UniqueId { get; set; }

        private readonly Panel pnlMailInfo = new Panel();
        private readonly Panel pnlBody = new Panel();
        private readonly FlowLayoutPanel pnlAttachments = new FlowLayoutPanel();
        private bool maxMin = true;
        private readonly Imap imap;
        public readonly MimeMessage message;

        public MailObject(Imap imap, MimeMessage message)
        {
            this.imap = imap;
            this.message = message;

            UniqueId = new UniqueId();
            Subject = new Label();
            From = new Label();
            Date = new Label();
            ChkSelect = new CheckBox();

            Label lblSubjectTag = new Label();
            Label lblToTag = new Label();
            Label lblDateTag = new Label();

            // 
            // pnlMailObject
            // 
            AutoSize = true;
            Controls.Add(pnlAttachments);
            Controls.Add(pnlBody);
            Controls.Add(pnlMailInfo);
            Dock = DockStyle.Top;
            Location = new System.Drawing.Point(0, 0);
            Name = "pnlMails";
            Size = new System.Drawing.Size(817, 485);
            TabIndex = 0;
            BackColor = System.Drawing.Color.AliceBlue;
            // 
            // pnlMailInfo
            // 
            pnlMailInfo.Controls.Add(Date);
            pnlMailInfo.Controls.Add(lblDateTag);
            pnlMailInfo.Controls.Add(Subject);
            pnlMailInfo.Controls.Add(lblSubjectTag);
            pnlMailInfo.Controls.Add(From);
            pnlMailInfo.Controls.Add(lblToTag);
            pnlMailInfo.Controls.Add(ChkSelect);
            pnlMailInfo.Dock = DockStyle.Top;
            pnlMailInfo.Location = new System.Drawing.Point(0, 0);
            pnlMailInfo.Name = "pnlMailInfo";
            pnlMailInfo.Size = new System.Drawing.Size(817, 43);
            pnlMailInfo.TabIndex = 0;
            pnlMailInfo.Click += new EventHandler(ViewMail);
            pnlMailInfo.BorderStyle = BorderStyle.FixedSingle;
            // 
            // pnlBody
            // 
            pnlBody.Dock = DockStyle.Top;
            pnlBody.Location = new System.Drawing.Point(0, 43);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new System.Drawing.Size(817, 392);
            pnlBody.TabIndex = 1;
            pnlBody.Visible = false;
            pnlBody.AutoScroll = true;
            pnlBody.BorderStyle = BorderStyle.FixedSingle;
            // 
            // pnlAttachments
            // 
            pnlAttachments.Dock = DockStyle.Top;
            pnlAttachments.Location = new System.Drawing.Point(0, 435);
            pnlAttachments.Name = "pnlAttachments";
            pnlAttachments.Size = new System.Drawing.Size(817, 50);
            pnlAttachments.TabIndex = 2;
            pnlAttachments.Visible = false;
            pnlAttachments.AutoScroll = true;
            pnlAttachments.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblFromTag
            // 
            lblToTag.AutoSize = true;
            lblToTag.Location = new System.Drawing.Point(20, 13);
            lblToTag.Name = "lblToTag";
            lblToTag.Size = new System.Drawing.Size(76, 17);
            lblToTag.TabIndex = 0;
            lblToTag.Text = "De:";
            lblToTag.Click += new EventHandler(ViewMail);
            // 
            // lblFrom
            // 
            From.AutoSize = true;
            From.Location = new System.Drawing.Point(40, 13);
            From.Name = "lblTo";
            From.Size = new System.Drawing.Size(46, 17);
            From.TabIndex = 1;
            //To.Text = message.From[0].Name;
            From.Click += new EventHandler(ViewMail);
            // 
            // lblSubjectTag
            // 
            lblSubjectTag.AutoSize = true;
            lblSubjectTag.Location = new System.Drawing.Point(240, 13);
            lblSubjectTag.Name = "lblSubjectTag";
            lblSubjectTag.Size = new System.Drawing.Size(56, 17);
            lblSubjectTag.TabIndex = 2;
            lblSubjectTag.Text = "Asunto:";
            lblSubjectTag.Click += new EventHandler(ViewMail);
            // 
            // lblSubject
            // 
            Subject.AutoSize = true;
            Subject.Location = new System.Drawing.Point(280, 13);
            Subject.Name = "lblSubject";
            Subject.Size = new System.Drawing.Size(46, 17);
            Subject.TabIndex = 3;
            Subject.TextChanged += new EventHandler(ChangeText);
            //Subject.Text = message.Subject;
            Subject.Click += new EventHandler(ViewMail);
            // 
            // lblDateTag
            // 
            lblDateTag.AutoSize = true;
            lblDateTag.Location = new System.Drawing.Point(720, 13);
            lblDateTag.Name = "lblDateTag";
            lblDateTag.Size = new System.Drawing.Size(51, 17);
            lblDateTag.TabIndex = 4;
            lblDateTag.Text = "Fecha:";
            lblDateTag.Click += new EventHandler(ViewMail);
            // 
            // lblDate
            // 
            Date.AutoSize = true;
            Date.Location = new System.Drawing.Point(760, 13);
            Date.Name = "lblDate";
            Date.Size = new System.Drawing.Size(46, 17);
            Date.TabIndex = 5;
            //Date.Text = message.Date.Date.ToString();
            Date.Click += new EventHandler(ViewMail);

            // 
            // chkSelectAll
            // 
            this.ChkSelect.AutoSize = true;
            this.ChkSelect.Location = new System.Drawing.Point(2, 13);
            this.ChkSelect.Name = "chkSelect";
            this.ChkSelect.Size = new System.Drawing.Size(136, 21);
            this.ChkSelect.TabIndex = 8;
            this.ChkSelect.UseVisualStyleBackColor = true;

        }

        private void ChangeText(object sender, EventArgs e)
        {
            int subjectLength = 60;

            if (Subject.Text.Length > subjectLength)
            {
                string text = Subject.Text.Substring(0, subjectLength) + "...";
                Subject.Text = text;
            }
        }

        private void ViewMail(object sender, EventArgs e)
        {
            if (maxMin)
            {
                pnlBody.Visible = true;
                maxMin = false;
                
                WebBrowser web;
                if (imap != null)
                {
                    web = new WebBrowser
                    {
                        DocumentText = imap.GetBodyMail(UniqueId),
                        Dock = DockStyle.Fill
                    };
                }
                else
                {
                    web = new WebBrowser
                    {
                        DocumentText = message.HtmlBody,
                        Dock = DockStyle.Fill
                    };
                }
                pnlBody.Controls.Add(web);

                if(imap != null)
                {
                    List<Button> attachments = imap.GetAttachmentsMail(UniqueId);
                    if (attachments != null && attachments.Count > 0) 
                    {
                        pnlAttachments.Visible = true;
                        foreach (var attachment in attachments)
                        {
                            attachment.Click += new EventHandler(DownloadAttachment);
                            pnlAttachments.Controls.Add(attachment);
                        }
                    }
                }
                else
                {
                    foreach (var a in message.BodyParts)
                    {
                        if (a.IsAttachment)
                        {
                            pnlAttachments.Visible = true;
                            pnlAttachments.Controls.Add(new Button
                            {
                                Text = a.ContentId,
                                AutoSize = true
                            });
                        }
                    }
                }
            }
            else
            {
                pnlAttachments.Visible = false;
                pnlBody.Visible = false;
                maxMin = true;
                pnlBody.Controls.Clear();
                pnlAttachments.Controls.Clear();
            }
        }

        private void DownloadAttachment(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            if(folder.ShowDialog() == DialogResult.OK)
            {
                imap.DownLoadAttachment(UniqueId, folder.SelectedPath);
            }
        }
    }
}
