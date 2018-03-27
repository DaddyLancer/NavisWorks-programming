//------------------------------------------------------------------
// NavisWorks Sample code
//------------------------------------------------------------------

// (C) Copyright 2010 by Autodesk Inc.

// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.

// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//------------------------------------------------------------------
//
// This sample shows the various aspects of the PublishProperties 
// class and using it with the PublishFile Method of Document
//
//------------------------------------------------------------------
// to experiment with this sample run with the following paramaters
// which uses the hello_world.nwd file created by the FileManipulation sample.
//
// /allowresave 1 /author "Author" /comments "comment" /copyright 2009 /displayatpassword 1 /displayonopen TRUE /embeddatabaseproperties true /embedtextures Yes /expirydate 01\03\2010 /keywords a,b,c /preventobjectpropertyexport y /publishdate 01\02\2010 /publishedfor "Navisworks Freedom" /publisher LB1 /subject theSubject /title "Hello World" /password HelloWorld /file .\hello_world.nwd /saveas .\output_saveas.nwd /publish .\output_publish.nwd
//
using System;
using System.Windows.Forms;
using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Controls;

namespace PublishFile
{
   class Program
   {
      [STAThread]
      static void Main(string[] args)
      {
         //Set to single document mode
         Autodesk.Navisworks.Api.Controls.ApplicationControl.ApplicationType = ApplicationType.SingleDocument;

         //Initialise the api
         ApplicationControl.Initialize();

         //Create a Document Control
         DocumentControl documentCtrl = new DocumentControl();

         //Set this to be the Main Document
         documentCtrl.SetAsMainDocument();

         //Get the publish properties
         PublishProperties publishProperties = GetPublishProperties(args, documentCtrl);

         try
         {
            //check we have a valid PublishProperties object
            if (publishProperties != null)
            {
               //open / merge files
               OpenFiles(args, documentCtrl);

               //save or publish files
               SaveFiles(args, publishProperties, documentCtrl);
            }
         }
         catch (DocumentFileException e)
         {
            Console.Write("Failed to publish file: \n" + e.Message);
         }
         catch (InvalidOperationException e)
         {
            Console.Write("Failed to publish file: Document may be clear\n" + e.Message);
         }

         //Dispose of the DocumentControl
         documentCtrl.Dispose();

         //Finish use of the API.
         ApplicationControl.Terminate();
      }

      /// <summary>
      /// Saves/Publishes the output 
      /// </summary>
      /// <param name="args"></param>
      /// <param name="publishProperties"></param>
      /// <param name="documentCtrl"></param>
      private static void SaveFiles(string[] args, PublishProperties publishProperties, DocumentControl documentCtrl)
      {
         //try and publish the files, if this fails it will throw a exception
         for (int i = 0; i < args.Length - 1; i++)
         {
            string s = args[i].ToLower();
            switch (s)
            {
               case "/publish":
                  documentCtrl.Document.PublishFile(args[i+1], publishProperties);
                  break;
               case "/saveas":
                  documentCtrl.Document.SaveFile(args[i+1], DocumentFileVersion.Current);
                  break;
               case "/saveas14":
                  documentCtrl.Document.SaveFile(args[i + 1], DocumentFileVersion.Navisworks2014);
                  break;
               case "/saveas15":
                  documentCtrl.Document.SaveFile(args[i + 1], DocumentFileVersion.Navisworks2015);
                  break;
               case "/saveas16":
                  documentCtrl.Document.SaveFile(args[i + 1], DocumentFileVersion.Navisworks2016);
                  break;
            }
         }
      }

      /// <summary>
      /// Opens files and merges them into the current Document
      /// </summary>
      /// <param name="args">the command line arguments</param>
      /// <param name="documentCtrl"></param>
      private static void OpenFiles(string[] args, DocumentControl documentCtrl)
      {
         bool hasOpenedFile = false;
         for (int i = 0; i < args.Length - 1; i++)
         {
            string s = args[i].ToLower();
            switch (s)
            {
               case "/file":
                  if (!hasOpenedFile)
                  {
                     documentCtrl.Document.OpenFile(args[i + 1]);
                     hasOpenedFile = true;
                  }
                  else
                  {
                     documentCtrl.Document.MergeFile(args[i + 1]);
                  }
                  break;
            }
         }
      }

      /// <summary>
      /// Parses the command line arguments for attributes applicable to PublishProperties
      /// </summary>
      /// <param name="args">the command line arguments</param>
      /// <param name="documentCtrl"></param>
      /// <returns>a valid <see cref="PublishProperties">PublishProperties</see> object</returns>
      private static PublishProperties GetPublishProperties(string[] args, DocumentControl documentControl)
      {
         PublishProperties publishProperties;
         publishProperties = new PublishProperties();
         for (int i = 0; i < args.Length-1; i++)
         {
            string s = args[i].ToLower();
            switch(s)
            {
               case "/allowresave":
                  publishProperties.AllowResave = IsTrue(args[i + 1]);
                  break;
               case "/author": 
                  publishProperties.Author = args[i + 1];
                  break;
               case "/comments": 
                  publishProperties.Comments = args[i + 1];
                  break;
               case "/copyright": 
                  publishProperties.Copyright = args[i + 1];
                  break;
               case "/displayatpassword": 
                  publishProperties.DisplayAtPassword = IsTrue(args[i + 1]);
                  break;
               case "/displayonopen": 
                  publishProperties.DisplayOnOpen = IsTrue(args[i + 1]);
                  break;
               case "/embeddatabaseproperties": 
                  publishProperties.EmbedDatabaseProperties = IsTrue(args[i + 1]);
                  break;
               case "/embedtextures": 
                  publishProperties.EmbedTextures = IsTrue(args[i + 1]);
                  break;
               case "/expirydate": 
                  publishProperties.ExpiryDate = DateTime.Parse(args[i + 1].Replace('\\', '/'));
                  break;
               case "/keywords": 
                  publishProperties.Keywords = args[i + 1];
                  break;
               case "/preventobjectpropertyexport": 
                  publishProperties.PreventObjectPropertyExport = IsTrue(args[i + 1]);
                  break;
               case "/publishdate":
                  publishProperties.PublishDate = DateTime.Parse(args[i + 1].Replace('\\', '/'));
                  break;
               case "/publishedfor": 
                  publishProperties.PublishedFor = args[i + 1];
                  break;
               case "/publisher": 
                  publishProperties.Publisher = args[i + 1];
                  break;
               case "/subject": 
                  publishProperties.Subject = args[i + 1];
                  break;
               case "/title": 
                  publishProperties.Title = args[i + 1];
                  break;
               case "/password": 
                  publishProperties.SetPassword(args[i + 1]);
                  break;
               case "/showform":
                  //this overrides all other options
                  PublishOptions dlg = new PublishOptions();
                  if (IsTrue(args[i + 1]) && dlg.ShowDialog() == DialogResult.OK)
                  {
                     publishProperties.AllowResave = dlg.AllowResave;
                     publishProperties.Author = dlg.Author;
                     publishProperties.Comments = dlg.Comments;
                     publishProperties.Copyright = dlg.Copyright;
                     publishProperties.DisplayAtPassword = dlg.DisplayAtPassword;
                     publishProperties.DisplayOnOpen = dlg.DisplayOnOpen;
                     publishProperties.EmbedDatabaseProperties = dlg.EmbedDatabaseProperties;
                     publishProperties.EmbedTextures = dlg.EmbedTextures;
                     publishProperties.ExpiryDate = dlg.Expires;
                     publishProperties.Keywords = dlg.Keywords;
                     publishProperties.PreventObjectPropertyExport = dlg.PreventObjectPropertyExport;
                     publishProperties.PublishDate = dlg.Published;
                     publishProperties.PublishedFor = dlg.PublishedFor;
                     publishProperties.Publisher = dlg.Publisher;
                     publishProperties.Subject = dlg.Subject;
                     publishProperties.Title = dlg.Title;
                     publishProperties.SetPassword(dlg.Password);

                     string[] files = dlg.Files;
                     for (int file = 0; file < dlg.Files.Length; file++)
                     {
                        if (file == 0)
                           documentControl.Document.OpenFile(files[file]);
                        else
                           documentControl.Document.MergeFile(files[file]);
                     }

                     documentControl.Document.PublishFile(dlg.FileName, publishProperties);
                     return null;
                  }
                  break;
            }
         }
         return publishProperties;
      }

      /// <summary>
      /// returns whether a given string can be considered a value of true
      /// </summary>
      /// <param name="arg">the string to evaluate</param>
      /// <returns>boolean value equivelent of true or false</returns>
      private static bool IsTrue(string arg)
      {
         return "trueyes1".Contains(arg.ToLower());
      }
   }
}
