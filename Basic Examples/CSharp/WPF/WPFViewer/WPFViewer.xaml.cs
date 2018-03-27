using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Navisworks.Api.Controls;
using System.Windows.Forms;

namespace WPFViewer
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class WPFViewerWindow : Window
   {
      DocumentControl documentControl = new DocumentControl();
      public WPFViewerWindow()
      {
         ApplicationControl.ApplicationType = ApplicationType.SingleDocument;
         ApplicationControl.Initialize();
         InitializeComponent();
         viewControl.DocumentControl = documentControl;
      }

      private void Window_Closed(object sender, EventArgs e)
      {
         viewControl.Dispose();
         ApplicationControl.Terminate();
      }

      private void fileOpen_Click(object sender, RoutedEventArgs e)
      {
         LoadDocument();
      }

      private void LoadDocument()
      {
         #region DocumentControlDocumentTryOpenFile
         //Dialog for selecting the Location of the file toolStripMenuItem1 open
         OpenFileDialog dlg = new OpenFileDialog();

         //Ask user for file location
         if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
         {
            //If the user has selected a valid location, then tell DocumentControl to open the file
            //As DocumentCtrl is linked to ViewControl
            documentControl.Document.TryOpenFile(dlg.FileName);

            Title = documentControl.Document.SuggestedFileName;
         }
         #endregion
      }
   }
}
