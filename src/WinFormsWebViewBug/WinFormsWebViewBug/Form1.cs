using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

namespace WinFormsWebViewBug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var uri = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                              @"\assets\APZ\indexHtmlFragment.html");
            webView1.NavigateToLocalStreamUri(uri, new CustomUriToStreamResolver());
        }
    }

    internal class CustomUriToStreamResolver
        : IUriToStreamResolver
    {
        public Stream UriToStream(Uri uri)
        {
            var stream = new FileStream(uri.AbsolutePath, FileMode.Open);
            return stream;
        }
    }
}