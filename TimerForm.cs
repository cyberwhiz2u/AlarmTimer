using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//For Timer
using System.Threading;
using System.Timers;
using System.IO;
using System.Reflection;
//For Mail
using System.Web;
using System.Web.Mail;
//For Command Line
using System.Diagnostics;
//For Sound
using System.Runtime.InteropServices;

namespace AlarmTimer
{
	/// <summary>
	/// Summary description for TimerForm.
	/// </summary>
	public class TimerForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		//Controls and Components
		private System.Windows.Forms.TextBox timerInput;
		private System.Windows.Forms.Button StartButton;
		private System.Windows.Forms.Button ResetButton;
		//Timer and associated variables
		private System.Timers.Timer timerClock = new System.Timers.Timer();
		private int clockTime = 0;
		private System.Windows.Forms.Button btnExec;
		private System.Windows.Forms.TextBox txtReminder;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.TextBox txtCmd;
		private System.Windows.Forms.TextBox txtInstances;
		private System.Windows.Forms.Button btnHelp;
		private System.Windows.Forms.Panel pnlMail;
		private System.Windows.Forms.Label lblFrom;
		private System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.Label lblCC;
		private System.Windows.Forms.Label lblBCC;
		private System.Windows.Forms.Label lblSubject;
		private System.Windows.Forms.Label lblAttch;
		private System.Windows.Forms.TextBox txtAttachment;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtSubject;
		private System.Windows.Forms.TextBox txtBCC;
		private System.Windows.Forms.TextBox txtCC;
		private System.Windows.Forms.TextBox txtTo;
		private System.Windows.Forms.TextBox txtFrom;
		private System.Windows.Forms.Button btnComposeMail;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.Button btnSendMail;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private int alarmTime = 0;
		//For Sound
		[DllImport("Kernel32.dll")]
		public static extern bool Beep(int freq, int duration);
		//For Panels
		private bool boolPnlValue=false;
		private bool boolPnlMailValue=false;

		public TimerForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			InitializeTimer();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.timerInput = new System.Windows.Forms.TextBox();
			this.StartButton = new System.Windows.Forms.Button();
			this.ResetButton = new System.Windows.Forms.Button();
			this.btnExec = new System.Windows.Forms.Button();
			this.txtReminder = new System.Windows.Forms.TextBox();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.txtInstances = new System.Windows.Forms.TextBox();
			this.txtCmd = new System.Windows.Forms.TextBox();
			this.btnComposeMail = new System.Windows.Forms.Button();
			this.btnHelp = new System.Windows.Forms.Button();
			this.pnlMail = new System.Windows.Forms.Panel();
			this.btnExit = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.txtFrom = new System.Windows.Forms.TextBox();
			this.txtTo = new System.Windows.Forms.TextBox();
			this.txtCC = new System.Windows.Forms.TextBox();
			this.txtBCC = new System.Windows.Forms.TextBox();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtAttachment = new System.Windows.Forms.TextBox();
			this.lblAttch = new System.Windows.Forms.Label();
			this.lblSubject = new System.Windows.Forms.Label();
			this.lblBCC = new System.Windows.Forms.Label();
			this.lblCC = new System.Windows.Forms.Label();
			this.lblTo = new System.Windows.Forms.Label();
			this.lblFrom = new System.Windows.Forms.Label();
			this.btnSendMail = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.pnlCommand.SuspendLayout();
			this.pnlMail.SuspendLayout();
			this.SuspendLayout();
			// 
			// timerInput
			// 
			this.timerInput.Location = new System.Drawing.Point(8, 13);
			this.timerInput.Name = "timerInput";
			this.timerInput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.timerInput.Size = new System.Drawing.Size(48, 20);
			this.timerInput.TabIndex = 0;
			this.timerInput.Text = "00:00:00";
			// 
			// StartButton
			// 
			this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.StartButton.Location = new System.Drawing.Point(64, 11);
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(88, 23);
			this.StartButton.TabIndex = 1;
			this.StartButton.Text = "&Start Timer";
			this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// ResetButton
			// 
			this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ResetButton.Location = new System.Drawing.Point(160, 11);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(80, 23);
			this.ResetButton.TabIndex = 2;
			this.ResetButton.Text = "&Reset Timer";
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// btnExec
			// 
			this.btnExec.Location = new System.Drawing.Point(8, 72);
			this.btnExec.Name = "btnExec";
			this.btnExec.Size = new System.Drawing.Size(120, 24);
			this.btnExec.TabIndex = 4;
			this.btnExec.Text = "&Execute Command";
			this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
			// 
			// txtReminder
			// 
			this.txtReminder.Location = new System.Drawing.Point(64, 40);
			this.txtReminder.Name = "txtReminder";
			this.txtReminder.Size = new System.Drawing.Size(176, 20);
			this.txtReminder.TabIndex = 3;
			this.txtReminder.Text = "Reminder Message";
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.txtInstances);
			this.pnlCommand.Controls.Add(this.txtCmd);
			this.pnlCommand.Location = new System.Drawing.Point(0, 104);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Size = new System.Drawing.Size(248, 32);
			this.pnlCommand.TabIndex = 7;
			// 
			// txtInstances
			// 
			this.txtInstances.Location = new System.Drawing.Point(8, 6);
			this.txtInstances.Name = "txtInstances";
			this.txtInstances.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtInstances.Size = new System.Drawing.Size(56, 20);
			this.txtInstances.TabIndex = 5;
			this.txtInstances.Text = "Instances";
			// 
			// txtCmd
			// 
			this.txtCmd.Location = new System.Drawing.Point(72, 6);
			this.txtCmd.Name = "txtCmd";
			this.txtCmd.Size = new System.Drawing.Size(168, 20);
			this.txtCmd.TabIndex = 6;
			this.txtCmd.Text = "Enter Command To Execute";
			// 
			// btnComposeMail
			// 
			this.btnComposeMail.Location = new System.Drawing.Point(136, 72);
			this.btnComposeMail.Name = "btnComposeMail";
			this.btnComposeMail.Size = new System.Drawing.Size(104, 23);
			this.btnComposeMail.TabIndex = 7;
			this.btnComposeMail.Text = "&Compose Mail";
			this.btnComposeMail.Click += new System.EventHandler(this.btnComposeMail_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Location = new System.Drawing.Point(8, 40);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(48, 23);
			this.btnHelp.TabIndex = 18;
			this.btnHelp.Text = "&Help";
			this.btnHelp.Visible = false;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// pnlMail
			// 
			this.pnlMail.Controls.Add(this.btnExit);
			this.pnlMail.Controls.Add(this.txtMessage);
			this.pnlMail.Controls.Add(this.txtFrom);
			this.pnlMail.Controls.Add(this.txtTo);
			this.pnlMail.Controls.Add(this.txtCC);
			this.pnlMail.Controls.Add(this.txtBCC);
			this.pnlMail.Controls.Add(this.txtSubject);
			this.pnlMail.Controls.Add(this.btnBrowse);
			this.pnlMail.Controls.Add(this.txtAttachment);
			this.pnlMail.Controls.Add(this.lblAttch);
			this.pnlMail.Controls.Add(this.lblSubject);
			this.pnlMail.Controls.Add(this.lblBCC);
			this.pnlMail.Controls.Add(this.lblCC);
			this.pnlMail.Controls.Add(this.lblTo);
			this.pnlMail.Controls.Add(this.lblFrom);
			this.pnlMail.Controls.Add(this.btnSendMail);
			this.pnlMail.Location = new System.Drawing.Point(0, 144);
			this.pnlMail.Name = "pnlMail";
			this.pnlMail.Size = new System.Drawing.Size(248, 288);
			this.pnlMail.TabIndex = 10;
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(8, 264);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(112, 23);
			this.btnExit.TabIndex = 17;
			this.btnExit.Text = "E&xit Mail";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(8, 144);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(232, 112);
			this.txtMessage.TabIndex = 15;
			this.txtMessage.Text = "";
			// 
			// txtFrom
			// 
			this.txtFrom.Location = new System.Drawing.Point(72, 0);
			this.txtFrom.Name = "txtFrom";
			this.txtFrom.Size = new System.Drawing.Size(168, 20);
			this.txtFrom.TabIndex = 8;
			this.txtFrom.Text = "";
			// 
			// txtTo
			// 
			this.txtTo.Location = new System.Drawing.Point(72, 24);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(168, 20);
			this.txtTo.TabIndex = 9;
			this.txtTo.Text = "";
			// 
			// txtCC
			// 
			this.txtCC.Location = new System.Drawing.Point(72, 48);
			this.txtCC.Name = "txtCC";
			this.txtCC.Size = new System.Drawing.Size(168, 20);
			this.txtCC.TabIndex = 10;
			this.txtCC.Text = "";
			// 
			// txtBCC
			// 
			this.txtBCC.Location = new System.Drawing.Point(72, 72);
			this.txtBCC.Name = "txtBCC";
			this.txtBCC.Size = new System.Drawing.Size(168, 20);
			this.txtBCC.TabIndex = 11;
			this.txtBCC.Text = "";
			// 
			// txtSubject
			// 
			this.txtSubject.Location = new System.Drawing.Point(72, 96);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(168, 20);
			this.txtSubject.TabIndex = 12;
			this.txtSubject.Text = "";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(184, 120);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(56, 24);
			this.btnBrowse.TabIndex = 14;
			this.btnBrowse.Text = "&Browse";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtAttachment
			// 
			this.txtAttachment.Location = new System.Drawing.Point(72, 120);
			this.txtAttachment.Name = "txtAttachment";
			this.txtAttachment.Size = new System.Drawing.Size(104, 20);
			this.txtAttachment.TabIndex = 13;
			this.txtAttachment.Text = "";
			// 
			// lblAttch
			// 
			this.lblAttch.Location = new System.Drawing.Point(8, 128);
			this.lblAttch.Name = "lblAttch";
			this.lblAttch.Size = new System.Drawing.Size(64, 16);
			this.lblAttch.TabIndex = 5;
			this.lblAttch.Text = "Attachment";
			// 
			// lblSubject
			// 
			this.lblSubject.Location = new System.Drawing.Point(8, 104);
			this.lblSubject.Name = "lblSubject";
			this.lblSubject.Size = new System.Drawing.Size(64, 16);
			this.lblSubject.TabIndex = 4;
			this.lblSubject.Text = "Subject";
			// 
			// lblBCC
			// 
			this.lblBCC.Location = new System.Drawing.Point(8, 80);
			this.lblBCC.Name = "lblBCC";
			this.lblBCC.Size = new System.Drawing.Size(64, 16);
			this.lblBCC.TabIndex = 3;
			this.lblBCC.Text = "BCC";
			// 
			// lblCC
			// 
			this.lblCC.Location = new System.Drawing.Point(8, 56);
			this.lblCC.Name = "lblCC";
			this.lblCC.Size = new System.Drawing.Size(64, 16);
			this.lblCC.TabIndex = 2;
			this.lblCC.Text = "CC";
			// 
			// lblTo
			// 
			this.lblTo.Location = new System.Drawing.Point(8, 32);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(64, 16);
			this.lblTo.TabIndex = 1;
			this.lblTo.Text = "To";
			// 
			// lblFrom
			// 
			this.lblFrom.Location = new System.Drawing.Point(8, 8);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(64, 16);
			this.lblFrom.TabIndex = 0;
			this.lblFrom.Text = "From";
			// 
			// btnSendMail
			// 
			this.btnSendMail.Location = new System.Drawing.Point(128, 264);
			this.btnSendMail.Name = "btnSendMail";
			this.btnSendMail.Size = new System.Drawing.Size(112, 23);
			this.btnSendMail.TabIndex = 16;
			this.btnSendMail.Text = "&Send Mail";
			this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
			// 
			// TimerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 435);
			this.Controls.Add(this.pnlMail);
			this.Controls.Add(this.btnHelp);
			this.Controls.Add(this.btnComposeMail);
			this.Controls.Add(this.pnlCommand);
			this.Controls.Add(this.txtReminder);
			this.Controls.Add(this.btnExec);
			this.Controls.Add(this.ResetButton);
			this.Controls.Add(this.StartButton);
			this.Controls.Add(this.timerInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "TimerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Alarm Timer";
			this.Resize += new System.EventHandler(this.TimerForm_Resized);
			this.Load += new System.EventHandler(this.TimerForm_Load);
			this.pnlCommand.ResumeLayout(false);
			this.pnlMail.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void InitializeTimer()
		{
			this.timerClock.Elapsed += new ElapsedEventHandler(OnTimer);
			this.timerClock.Interval = 1000;
			this.timerClock.Enabled = true;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new TimerForm());
		}

		private void TimerForm_Resized(object sender, System.EventArgs e)
		{
			if( this.WindowState == FormWindowState.Minimized )
			{
				this.Hide();
			}
		}

		private void StartButton_Click(object sender, System.EventArgs e)
		{
			this.clockTime = 0;
			inputToSeconds( this.timerInput.Text );
			//Hiding the application till time set
			this.Hide();
		}

		private void ResetButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.clockTime = 0;
				this.alarmTime = 0;
				this.timerInput.Text = "00:00:00";
			}
			catch( Exception ex )
			{
				MessageBox.Show("ResetButton_Click(): " + ex.Message );
			}
		}

		public void OnTimer(Object source, ElapsedEventArgs e)
		{
			try
			{
				this.clockTime++;
				int countdown = this.alarmTime - this.clockTime ;
				if( this.alarmTime != 0 )
				{
					this.timerInput.Text = secondsToTime(countdown);
				}

				if( this.clockTime == this.alarmTime )
				{
					#region Sound	
					//For Sound
					for(int i=0; i<=5; i++)
					{
						Beep(1000,500);
					}
					#endregion Sound
						
					#region Command Line
					//For Command Line
					if( (txtCmd.Text.Trim()== "Enter Command To Execute") || (txtCmd.Text.Trim()== ""))
					{
						//Do Nothing
					}
					else
					{
						int counter = 1;
						while(counter <= Convert.ToInt16(txtInstances.Text.Trim()))
						{
							//Declare and instantiate a new process component.
							System.Diagnostics.Process process1;
							process1= new System.Diagnostics.Process();
							//Do not receive an event when the process exits.
							process1.EnableRaisingEvents = false;
							//The "/C" Tells Windows to Run The Command then Terminate 
							string strCmdLine;
							strCmdLine = "/C " + txtCmd.Text.Trim();
							System.Diagnostics.Process.Start("CMD.exe",strCmdLine);
							process1.Close();
							counter = counter + 1;
						}
					}
					#endregion Command Line

					#region Mail
					if(txtTo.Text.Trim()== "")
					{
						//Do Nothing
					}
					else
					{
						// Construct a new mail message and fill it with information from the form
						MailMessage msgMail = new MailMessage();
						msgMail.From = txtFrom.Text;
						msgMail.To = txtTo.Text;
						msgMail.Cc = txtCC.Text;
						msgMail.Bcc = txtBCC.Text;
						msgMail.Subject = txtSubject.Text;
						msgMail.Body = txtMessage.Text; 
						// if an attachment file is indicated, create it and add it to the message
						if (txtAttachment.Text.Length > 0)
							msgMail.Attachments.Add(new MailAttachment(txtAttachment.Text, MailEncoding.Base64));
						// Now send the message
						SmtpMail.Send(msgMail);
						// Indicate that the message has been sent
						string strSentMail="";
						strSentMail = "Message Sent to " + txtTo.Text;
						if(txtCC.Text!="")
							strSentMail+= " Carbon Copy Sent to " + txtCC.Text;
						if(txtBCC.Text!="")
							strSentMail+= " Blind Carbon Copy Sent to " + txtBCC.Text;
						MessageBox.Show(strSentMail);
					}
					#endregion Mail
					
					//Show the Window again
					MessageBox.Show (txtReminder.Text.Trim(), "Alarm Timer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtCmd.Text = "Enter Command To Execute";
					this.txtInstances.Text = "Instances";
					this.txtReminder.Text = "Reminder Message";
					this.Show();
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show("OnTimer(): " + ex.Message );
			}        
		}

		private void inputToSeconds( string timerInput )
		{
			try
			{
				string[] timeArray = new string[3];
				int minutes = 0;
				int hours = 0;
				int seconds = 0;
				int occurence = 0;
				int length = 0;

				occurence = timerInput.LastIndexOf(":");
				length = timerInput.Length;

				//Check for invalid input
				if( occurence == -1 || length != 8 )
				{
					MessageBox.Show("Invalid Time Format.");
					ResetButton_Click( null, null );
				}
				else
				{
					timeArray = timerInput.Split(':');

					seconds = Convert.ToInt32( timeArray[2] );
					minutes = Convert.ToInt32( timeArray[1] );
					hours = Convert.ToInt32( timeArray[0] );

					this.alarmTime += seconds;
					this.alarmTime += minutes*60;
					this.alarmTime += (hours*60)*60;
				}
			}
			catch( Exception e )
			{
				MessageBox.Show("inputToSeconds(): " + e.Message );
			}
		}

		public string secondsToTime( int seconds )
		{
			int minutes = 0;
			int hours = 0;

			while( seconds >= 60 )
			{
				minutes += 1;
				seconds -= 60;
			}
			while( minutes >= 60 )
			{
				hours += 1;
				minutes -= 60;
			}

			string strHours = hours.ToString();
			string strMinutes = minutes.ToString();
			string strSeconds = seconds.ToString();

			if( strHours.Length < 2 ) 
				strHours = "0" + strHours;
			if( strMinutes.Length < 2 ) 
				strMinutes = "0" + strMinutes;
			if( strSeconds.Length < 2 ) 
				strSeconds = "0" + strSeconds;

			return strHours + ":" + strMinutes + ":" + strSeconds;
		}

		private void btnExec_Click(object sender, System.EventArgs e)
		{
			if(boolPnlValue==true)
				boolPnlValue=false;
			else
				boolPnlValue=true;
			if(boolPnlValue)
				pnlCommand.Visible=true;
			else
				pnlCommand.Visible=false;
		}

		private void TimerForm_Load(object sender, System.EventArgs e)
		{
			if(boolPnlValue)
				pnlCommand.Visible=true;
			else
				pnlCommand.Visible=false;

			if(boolPnlMailValue)
				pnlMail.Visible=true;
			else
				pnlMail.Visible=false;
		}

		private void btnComposeMail_Click(object sender, System.EventArgs e)
		{
			if(boolPnlMailValue==true)
				boolPnlMailValue=false;
			else
				boolPnlMailValue=true;
			if(boolPnlMailValue)
				pnlMail.Visible=true;
			else
				pnlMail.Visible=false;
		}

		private void btnSendMail_Click(object sender, System.EventArgs e)
		{
			try
			{
				// Construct a new mail message and fill it with information from the form
				MailMessage msgMail = new MailMessage();
				msgMail.From = txtFrom.Text;
				msgMail.To = txtTo.Text;
				msgMail.Cc = txtCC.Text;
				msgMail.Bcc = txtBCC.Text;
				msgMail.Subject = txtSubject.Text;
				msgMail.Body = txtMessage.Text; 
				// if an attachment file is indicated, create it and add it to the message
				if (txtAttachment.Text.Length > 0)
					msgMail.Attachments.Add(new MailAttachment(txtAttachment.Text, MailEncoding.Base64));
				// Now send the message
				SmtpMail.Send(msgMail);
				// Indicate that the message has been sent
				string strSentMail="";
				strSentMail = "Message Sent to " + txtTo.Text;
                if(txtCC.Text!="")
					strSentMail+= " Carbon Copy Sent to " + txtCC.Text;
				if(txtBCC.Text!="")
					strSentMail+= " Blind Carbon Copy Sent to " + txtBCC.Text;
				MessageBox.Show(strSentMail);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			txtFrom.Text="";
			txtTo.Text="";
			txtCC.Text="";
			txtBCC.Text="";
			txtSubject.Text="";
			txtMessage.Text=""; 
			txtAttachment.Text="";
			pnlMail.Visible=false;
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				txtAttachment.Text = this.openFileDialog1.FileName;
			}

		}

		private void btnHelp_Click(object sender, System.EventArgs e)
		{
//			This is to show the use of Stream Reader just in case you are interested!!!!
//			StreamReader SR;
//			string  S;
//			string szCurrDir=Directory.GetCurrentDirectory();
//			szCurrDir = szCurrDir + "\\helpFile.txt" ;
//			SR=File.OpenText(szCurrDir);
//			S=SR.ReadToEnd();
//			SR.Close();
//			MessageBox.Show(S);

			//I'm not using this now...but it does work after you make sure to reove the @ from 
			//szCurrDir after you GetCurrentDirectory() itself.
			string szCurrDir=Directory.GetCurrentDirectory();
			szCurrDir = szCurrDir + "\\helpFile.txt" ;
			System.Diagnostics.Process process2;
			process2= new System.Diagnostics.Process();
			process2.EnableRaisingEvents = false;
			string strCmdLine;
			strCmdLine = " notepad "  + szCurrDir.Trim();
			System.Diagnostics.Process.Start("CMD.exe",strCmdLine);
			process2.Close();
		}
	}
}
