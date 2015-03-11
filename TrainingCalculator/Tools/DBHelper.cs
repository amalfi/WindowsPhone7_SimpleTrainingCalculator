﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using Community.CsharpSqlite.SQLiteClient;
using System.IO;
using System.Reflection;


namespace TrainingCalculator.Tools
{
    public class DBHelper
    {

        private String dbName = "trainings.sqlite";
        private SqliteConnection db = null;
        private SqliteCommand cmd;

        public void DBmanager()
        {
            // Załadowanie pliku bazy danych do IsolatedStorage jeśli jeszcze go tam nie ma
            Assembly assem = Assembly.GetExecutingAssembly();
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            if (!store.FileExists(dbName))
            {
                CopyFromContentToStorage(assem.FullName.Substring(0, assem.FullName.IndexOf(',')), dbName);
            }
        }

         // Otwarcie połączenia
        private void Open()
        {
            if (db == null)
            {
                db = new SqliteConnection("Version=3,uri=file:trainings.sqlite");
                cmd = db.CreateCommand();
                db.Open();
            }
        }

        // Zamknięcie połączenia
        private void Close()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }

     
        // Metoda kopiująca strumień pliku do IsolatedStorage
        private void CopyFromContentToStorage(String assemblyName, String dbName)
        {
            IsolatedStorageFile store =
                IsolatedStorageFile.GetUserStoreForApplication();
            System.IO.Stream src =
                Application.GetResourceStream(
                    new Uri("/" + assemblyName + ";component/" + dbName,
                            UriKind.Relative)).Stream;
            IsolatedStorageFileStream dest =
                new IsolatedStorageFileStream(dbName,
                    System.IO.FileMode.OpenOrCreate,
                    System.IO.FileAccess.Write, store);
            src.Position = 0;
            CopyStream(src, dest);
            dest.Flush();
            dest.Close();
            src.Close();
            dest.Dispose();
        }

        // Metoda wspierająca kopiowanie strumienia pliku do IsolatedStorage
        private static void CopyStream(System.IO.Stream input,
                                        IsolatedStorageFileStream output)
        {
            byte[] buffer = new byte[32768];
            long TempPos = input.Position;
            int readCount;
            do
            {
                readCount = input.Read(buffer, 0, buffer.Length);
                if (readCount > 0)
                {
                    output.Write(buffer, 0, readCount);
                }
            } while (readCount > 0);
            input.Position = TempPos;
        }
    }
}
