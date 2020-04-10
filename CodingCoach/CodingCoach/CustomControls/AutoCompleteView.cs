using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodingCoach.CustomControls
{
   public class AutoCompleteView : ContentView
   {
      public AutoCompleteView()
      {
         try
         {
            var stackLayout = new StackLayout();
            _entry = new Editor();
            var listView = new ListView
            {
               IsVisible           = false,
               SeparatorVisibility = SeparatorVisibility.Default,
               SeparatorColor      = Color.Gray,
               HasUnevenRows       = true
            };
            listView.BindingContext = this;
            listView.SetBinding( HorizontalOptionsProperty, "HorizontalOptions" );
            listView.SetBinding( WidthRequestProperty, "WidthRequest" );
            listView.ItemTemplate = new DataTemplate( () =>
            {
               var label = new Label();
               label.SetBinding( Label.TextProperty, "Value" );
               label.SetDynamicResource( StyleProperty, "LabelStyle" );
               label.FontSize = 12;
               // Left for reference, old separator format
               //var separator = new BoxView { Color = Color.Gray, HeightRequest = 1.5, Opacity = 0.5 };
               return new ViewCell
               {
                  View = new StackLayout
                  {
                     Orientation     = StackOrientation.Vertical,
                     VerticalOptions = LayoutOptions.CenterAndExpand,
                     Children =
                     {
                        label
                     }
                  }
               };
            } );
            _entry.BindingContext = this;
            _entry.SetBinding( BackgroundColorProperty, "TextBackgroundColor" );
            _entry.SetBinding( HorizontalOptionsProperty, "HorizontalOptions" );
            _entry.SetBinding( WidthRequestProperty, "WidthRequest" );
            _entry.SetBinding( IsEnabledProperty, "IsEnabled" );
            _entry.SetDynamicResource( StyleProperty, "ExpandingFormEditorStyle" );
            _tapGestureRecognizer = new TapGestureRecognizer();
            _tapGestureRecognizer.Tapped += delegate
            {
               SetText( string.Empty );
               _entry.IsEnabled = true;
               IsEditing        = true;
               ClearSelectedItem();
               listView.IsVisible = false;
               _entry.Focus();
               if ( Device.RuntimePlatform == Device.iOS )
               {
                  RemoveGestureRecognizer();
               }
            };
            _entry.TextChanged += delegate
            {
               try
               {
                  if ( !string.IsNullOrWhiteSpace( _entry.Text ) &&
                       _entry.Text.Length >= MinimumCharacters )
                  {
                     IList<KeyValuePair<string, string>> results = null;
                     if ( ItemsSource != null )
                     {
                        results = ItemsSource
                                  .Where( x => !string.IsNullOrWhiteSpace( x.Value ) &&
                                               x.Value.ToLower().Contains( _entry.Text.ToLower() ) )
                                  .ToList();
                     }
                     if ( results?.Any() ?? false )
                     {
                        if ( results.Any() &&
                             results.First().Value == _entry.Text )
                        {
                           listView.IsVisible = false;
                        }
                        else
                        {
                           ClearSelectedItem();
                           listView.ItemsSource = results;
                           listView.IsVisible   = true;
                        }
                     }
                     else
                     {
                        ClearSelectedItem();
                        listView.IsVisible = false;
                     }
                  }
                  else
                  {
                     ClearSelectedItem();
                     listView.IsVisible = false;
                  }
               }
               catch (Exception e)
               {
                  Debug.WriteLine( e.Message );
               }
            };
            GestureRecognizers.Add( _tapGestureRecognizer );
            _entry.IsEnabled = false;
            IsEditing        = false;
            listView.ItemSelected += ( s,
                                       e ) =>
            {
               SelectedItem = (KeyValuePair<string, string>) e.SelectedItem;
               SetText( ( (KeyValuePair<string, string>) e.SelectedItem ).Value );
               _entry.IsEnabled = false;
               IsEditing        = false;
               AddClearRecognizer();
               if ( OnSelectionCommand?.CanExecute( SelectedItem.Key ) ?? false )
                  OnSelectionCommand?.Execute( SelectedItem.Key );
            };
            stackLayout.Children.Add( _entry );
            stackLayout.Children.Add( listView );
            Content = stackLayout;
         }
         catch (Exception ex)
         {
            Debug.WriteLine( ex.Message );
         }
      }

      public Color TextBackgroundColor
      {
         get => (Color) GetValue( TextBackgroundColorProperty );
         set => SetValue( TextBackgroundColorProperty, value );
      }

      public IList<KeyValuePair<string, string>> ItemsSource
      {
         get => (IList<KeyValuePair<string, string>>) GetValue( ItemsSourceProperty );
         set => SetValue( ItemsSourceProperty, value );
      }

      public KeyValuePair<string, string> SelectedItem
      {
         get => (KeyValuePair<string, string>) GetValue( SelectedItemProperty );
         set => SetValue( SelectedItemProperty, value );
      }

      public bool IsEditing
      {
         get => (bool) GetValue( IsEditingProperty );
         set => SetValue( IsEditingProperty, value );
      }

      public ICommand OnSelectionCommand
      {
         get => (ICommand) GetValue( OnSelectionCommandProperty );
         set => SetValue( OnSelectionCommandProperty, value );
      }

      public string Text { get; private set; }

      public void SetText( string text )
      {
         Text        = text;
         _entry.Text = text;
      }

      public int MinimumCharacters { get; set; }
      public static readonly BindableProperty TextBackgroundColorProperty = BindableProperty.Create(
         "TextBackgroundColor",
         typeof(Color),
         typeof(AutoCompleteView),
         Color.Gray
      );
      public static readonly BindableProperty OnSelectionCommandProperty = BindableProperty.Create(
         "OnSelectionCommand",
         typeof(ICommand),
         typeof(AutoCompleteView)
      );
      public static readonly BindableProperty IsEditingProperty = BindableProperty.Create(
         "IsEditing",
         typeof(bool),
         typeof(AutoCompleteView),
         false
      );
      public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
         "ItemsSource",
         typeof(IList<KeyValuePair<string, string>>),
         typeof(AutoCompleteView)
      );
      public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
         "SelectedItem",
         typeof(KeyValuePair<string, string>),
         typeof(AutoCompleteView),
         new KeyValuePair<string, string>(),
         BindingMode.TwoWay,
         propertyChanged: ( b,
                            o,
                            n ) =>
         {
            // The setter for SelecteItem is not raised when the binded object change
            // We need to use this method to respond to the changing value

            // When the selected item change, we set the text value for the entry
            // When the entry is set, the text changed event fire, if there is any selected item
            //    the list view will be hide
            try
            {
               var control  = (AutoCompleteView) b;
               var newValue = (KeyValuePair<string, string>) n;
               if ( !control.IsEditing )
               {
                  control.SetText( newValue.Value );
               }
            }
            catch (Exception e)
            {
               Debug.WriteLine( e.Message );
            }
         }
      );
      private readonly Editor               _entry;
      private readonly TapGestureRecognizer _tapGestureRecognizer;

      private void AddClearRecognizer()
      {
         if ( !GestureRecognizers.Contains( _tapGestureRecognizer ) )
         {
            GestureRecognizers.Add( _tapGestureRecognizer );
         }
      }

      private void RemoveGestureRecognizer()
      {
         if ( GestureRecognizers.Contains( _tapGestureRecognizer ) )
         {
            GestureRecognizers.Remove( _tapGestureRecognizer );
         }
      }

      private void ClearSelectedItem()
      {
         SelectedItem = new KeyValuePair<string, string>( null, null );
      }

      public new void Focus()
      {
         _entry.Focus();
      }
   }
}