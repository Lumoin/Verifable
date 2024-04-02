using System;
using System.ComponentModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Verifable.General;

namespace Verifable
{    
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public Engine Engine { get; }

        private readonly IPlatformService platformDiTestService;
        private string sayYourPlatformNameValue = "Click the 'Reveal platform' button";
        private string reactiveProperty = "Start value";        
        public event PropertyChangedEventHandler PropertyChanged;

        private IDisposable ReactiveObserver { get; set; }
        
        public MainPageViewModel(Engine engine, IPlatformService platformDiTestService)
        {
            Engine = engine;
            this.platformDiTestService = platformDiTestService;
            
            //ReactiveObserver = Engine.TestObservable.Subscribe(i => ReactiveProperty = i.ToString());
            //ReactiveObserver = Engine.TestObservable.Subscribe(i => ReactiveProperty = i.ToString());
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ReactiveProperty
        {
            get => reactiveProperty;
            set
            {
                reactiveProperty = value;
                OnPropertyChanged(nameof(this.ReactiveProperty));
            }
        }

        public string SayYourPlatformNameValue
        {
            get => platformDiTestService.Hello();
            set
            {
                sayYourPlatformNameValue = value;
                OnPropertyChanged(nameof(this.SayYourPlatformNameValue));
            }
        }

        //public Command SayYourPlatformNameCommand => sayYourPlatformNameCommand ??= new Command(() => { this.SayYourPlatformNameValue = platformDiTestService.SayYourPlatformName(); });
    }
}
