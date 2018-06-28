﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MusicLibraryApp
{
    public sealed partial class AddSongContentDialog : ContentDialog
    {
        public AddSongContentDialog()
        {
            this.InitializeComponent();
        }
        private void ContentDialog_AddButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var song = new Model.Song
            {
                Title = Title.Text,
                Artist = Artist.Text,
                Album = "Pop",
                AudioFilePath = Song.Text
            };
            FileHelper.WriteSongToFileAsync(song);

        }

        private void ContentDialog_CancelButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
       

        private async void ContentDialog_TakeImage_Clicked(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();

            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.List;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
            picker.FileTypeFilter.Add(".mp3");
            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.Song.Text =  file.Path;
            }
        }
        
    }
}