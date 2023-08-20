using System;
using System.ComponentModel;
using System.Numerics;

namespace EldenTracker.Model
{
    internal sealed class PointOfInterest : INotifyPropertyChanged
    {
        private string _description;
        
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public Uri ImageSource { get; set; }
        
        public double XCoordinate { get; set; }
        
        public double YCoordinate { get; set; }

        public enum Type : byte
        {
            Default,
            Custom
        }

        public PointOfInterest(Vector2 translate, Type type = Type.Default)
        {
            XCoordinate = translate.X;
            YCoordinate = translate.Y;
            ImageSource = GetImageUri(type);
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static Uri GetImageUri(Type type)
        {
            var name = type == Type.Default
                ? nameof(Type.Default)
                : nameof(Type.Custom);
            return new Uri($"ms-appx:///Assets/{name}Point.png");
        }
    }
}